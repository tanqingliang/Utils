package Utils

import (
	"encoding/base64"
	"errors"
	"net/url"
)

// Base64 -> 编码
func Base64Encode(input []byte) string {
	if input == nil {
		return ""
	}
	return base64.StdEncoding.EncodeToString(input)
}

// Base64 -> 解码
func Base64Decode(input string) ([]byte, error) {
	if input == "" {
		return nil, errors.New("content can not be blank")
	}
	return base64.StdEncoding.DecodeString(input)
}

// Url -> 编码
func UrlEncode(input string) string {
	return url.QueryEscape(input)
}

// Url -> 解码
func UrlDecode(input string) (string, error) {
	return url.QueryUnescape(input)
}
