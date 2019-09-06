package Utils

import (
	"fmt"
	"testing"
)

func TestMarshalJson(t *testing.T) {
	data := map[string]interface{}{
		"a": 1,
		"b": "2",
		"c": 3.0,
		"d": true,
	}

	fmt.Printf("原始数据：%v \n", data)

	b, err := MarshalJson(data)

	fmt.Printf("序列化数据：%v err: %v \n", string(b), err)

	newData := map[string]interface{}{}

	err = UnmarshalJson(b, &newData)
	fmt.Printf("反序列化数据：%v err: %v \n", newData, err)

}

func TestMarshalXml(t *testing.T) {
	data := map[string]interface{}{
		"a": 1,
		"b": "2",
		"c": 3.0,
		"d": true,
	}

	fmt.Printf("原始数据：%v \n", data)
	b, err := MarshalXml(&data)
	fmt.Printf("序列化数据：%v err: %v \n", string(b), err)

	newData := map[string]interface{}{
		"a": 10,
		"e": 101,
	}
	err = UnmarshalXml(b, &newData)
	fmt.Printf("反序列数据：%v ,err: %v \n", newData, err)

	user := User{1, "test", ""}
	fmt.Printf("原始数据：%v \n", user)
	b, err = MarshalXml(&user)
	fmt.Printf("序列化数据：%v ,err: %v \n", string(b), err)

	var newUser User
	err = UnmarshalXml(b, &newUser)
	fmt.Printf("反序列数据：%v ,err: %v \n", newUser, err)

}

type User struct {
	Id    int
	Name  string
	Error string
}

func TestStructToMap(t *testing.T) {

	user := User{1, "test", ""}
	fmt.Printf("原始数据：%v \n", user)
	data, err := StructToMap(&user)
	fmt.Printf("转换后数据：%v ,err: %v \n", data, err)

	newUser := User{}
	err = MapToStruct(map[string]interface{}{
		"Id":    3,
		"Name":  "Name",
		"Error": "err",
	}, &newUser)
	fmt.Printf("转换后数据：%v ,err: %v \n", newUser, err)

}
