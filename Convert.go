package Utils

import (
	"encoding/json"
	"encoding/xml"
	"errors"
	"fmt"
	"io"
	"reflect"
)

// 序列化 Json
// v 需转换数据
func MarshalJson(v interface{}) ([]byte, error) {

	// 判断对象是否为空
	if v == nil {
		return nil, errors.New("object cannot be empty")
	}

	return json.Marshal(&v)
}

// 反序列化 Json
// data 反转换数据
// v 接收对象
func UnmarshalJson(data []byte, v interface{}) error {

	// 判断对象是否为空
	if data == nil {
		return errors.New("data cannot be empty")
	}

	return json.Unmarshal(data, v)
}

// 序列化 Xml 数据
// v 需转换数据 , 注：map 类型只支持 map[string]interface{}
func MarshalXml(v interface{}) ([]byte, error) {

	// 判断对象是否为空
	if v == nil {
		return nil, errors.New("object cannot be empty")
	}

	t := reflect.TypeOf(v)
	kind := t.Kind()

	if kind == reflect.Map {
		newv := mapXml(v.(map[string]interface{}))
		return xml.Marshal(&newv)

	} else if kind == reflect.Ptr && t.Elem().Kind() == reflect.Map {
		newv := mapXml(reflect.ValueOf(v).Elem().Interface().(map[string]interface{}))
		return xml.Marshal(&newv)
	}

	return xml.Marshal(v)

}

// 反序列化 Xml 数据
// data 反转换数据
// v 接收对象 , 注：map 类型只支持 map[string]interface{}
func UnmarshalXml(data []byte, v interface{}) error {

	// 判断对象是否为空
	if v == nil {
		return errors.New("data cannot be empty")
	}

	t := reflect.TypeOf(v)
	kind := t.Kind()

	if kind == reflect.Ptr && t.Elem().Kind() == reflect.Map {
		nv := mapXml{}
		err := xml.Unmarshal(data, &nv)
		if err != nil {
			return err
		}

		reflect.ValueOf(v).Elem().Set(reflect.ValueOf(nv))
		return nil
	}

	return xml.Unmarshal(data, v)
}

// map to xml 对象
type mapXml map[string]interface{}
type xmlMapEntry struct {
	XMLName xml.Name
	Value   string `xml:",xml"`
}

// 自定义map to xml序列化
func (m mapXml) MarshalXML(e *xml.Encoder, start xml.StartElement) error {

	if len(m) == 0 {
		return nil
	}

	err := e.EncodeToken(start)
	if err != nil {
		return err
	}

	for k, v := range m {
		// 转换字符串字节
		s := fmt.Sprintf("%v", v.(interface{}))

		e.Encode(xmlMapEntry{XMLName: xml.Name{Local: k}, Value: s})
	}

	return e.EncodeToken(start.End())
}

// 自定义xml to map反序列化
func (m *mapXml) UnmarshalXML(d *xml.Decoder, start xml.StartElement) error {
	*m = mapXml{}
	// fmt.Println(m)
	for {
		var e xmlMapEntry

		err := d.Decode(&e)
		if err == io.EOF {
			break
		} else if err != nil {
			return err
		}

		(*m)[e.XMLName.Local] = e.Value
	}
	// fmt.Println(m)
	return nil
}

// Struct 转 Map 格式数据
// v 需转换数据 ,注：只支持Struct对象
func StructToMap(v interface{}) (map[string]interface{}, error) {

	// 判断对象是否为空
	if v == nil {
		return nil, errors.New("object cannot be empty")
	}

	// 类型
	vt := reflect.TypeOf(v)

	// 值
	var vv reflect.Value

	if vt.Kind() == reflect.Struct {
		vv = reflect.ValueOf(v)
	} else if vt.Kind() == reflect.Ptr && vt.Elem().Kind() == reflect.Struct {
		vt = reflect.TypeOf(v).Elem()
		vv = reflect.ValueOf(v).Elem()
	} else {
		return nil, errors.New("object type error")
	}

	// 返回对象
	var data = make(map[string]interface{})

	// 循环赋值
	for i := 0; i < vt.NumField(); i++ {
		data[vt.Field(i).Name] = vv.Field(i).Interface()
	}

	return data, nil

}

// Map 转 Struct 格式数据
// data 反转换数据
// v 接收对象 , 注：只支持 Struct
func MapToStruct(data map[string]interface{}, v interface{}) error {

	// 判断对象是否为空
	if data == nil {
		return errors.New("data cannot be empty")
	}

	t := reflect.TypeOf(v)

	if t.Kind() != reflect.Ptr {
		return errors.New("non-pointer passed to Unmarshal")
	} else if t.Elem().Kind() != reflect.Struct {
		return errors.New("object format error")
	}

	// 循环字段赋值
	for name, value := range data {

		structValue := reflect.ValueOf(v).Elem()
		structFieldValue := structValue.FieldByName(name)

		if !structFieldValue.IsValid() {
			continue
		}

		if !structFieldValue.CanSet() {
			return fmt.Errorf("Cannot set %s field value", name)
		}

		structFieldType := structFieldValue.Type()
		val := reflect.ValueOf(value)
		if structFieldType != val.Type() {
			invalidTypeError := errors.New("Provided value type didn't match obj field type")
			return invalidTypeError
		}

		structFieldValue.Set(val)

	}

	return nil

}
