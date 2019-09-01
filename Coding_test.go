package Utils

import (
	"fmt"
	"testing"
)

// 测试base64
func TestBase64(t *testing.T) {

	input := "你好，世界！ hello world"

	t.Log("原数据 -> " + input)

	encodeData := Base64Encode([]byte(input))
	t.Log("Base64 编码 -> " + encodeData)

	// decode
	dncodeData, err := Base64Decode(encodeData)
	if err != nil {
		t.Log(err.Error())
	}
	t.Log("Base64 解码 -> " + string(dncodeData))
}

// 测试Url
func TestUrl(t *testing.T) {
	input := "http://www.baidu.com/s?wd=自由度"

	encodeData := UrlEncode(input)
	t.Log("Url 编码 -> " + encodeData)

	dncodeData, err := UrlDecode(encodeData)
	if err != nil {
		t.Log(err.Error())
	}
	t.Log("Url 解码 -> " + dncodeData)

}

func Test2Ary(t *testing.T) {
	fmt.Println([]byte("谭青亮"))
	fmt.Println(len("谭青亮"))
}

// Binary
