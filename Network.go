package Utils

import (
	"bytes"
	"io"
	"io/ioutil"
	"mime/multipart"
	"net/http"
	"net/url"
	"os"
	"path"
)

// Get 请求
// uri 请求地址
// data 请求数据
func Get(uri string, data *map[string]string) ([]byte, error) {

	// 判断是否有参数
	if data != nil {
		// 请求地址解析
		reqUrl, err := url.Parse(uri)
		if err != nil {
			return nil, err
		}

		// 请求数据合并
		query := reqUrl.Query()
		for k, v := range *data {
			query.Set(k, v)
		}
		reqUrl.RawQuery = query.Encode()

		uri = reqUrl.String()
	}

	response, err := http.Get(uri)

	//程序在使用完回复后必须关闭回复的主体。
	if response != nil {
		defer response.Body.Close()
	}

	// 请求错误
	if err != nil {
		return nil, err
	}

	return ioutil.ReadAll(response.Body)
}

// Http Post form 请求
// uri 请求地址
// data 请求数据
func PostForm(uri string, data *map[string][]string) ([]byte, error) {
	// 发送请求
	response, err := http.PostForm(uri, *data)

	//程序在使用完回复后必须关闭回复的主体。
	if response != nil {
		defer response.Body.Close()
	}

	// 请求错误
	if err != nil {
		return nil, err
	}

	return ioutil.ReadAll(response.Body)
}

// Http Post Json 请求
// uri 请求地址
// data 请求数据
func PostJson(uri string, data *string) ([]byte, error) {

	// 发送请求
	response, err := http.Post(uri, "application/json;charset=utf-8", bytes.NewReader([]byte(*data)))

	//程序在使用完回复后必须关闭回复的主体。
	if response != nil {
		defer response.Body.Close()
	}

	// 请求错误
	if err != nil {
		return nil, err
	}

	return ioutil.ReadAll(response.Body)
}

// Http Post File 请求
// uri 请求地址
// data 请求数据
// files 请求文件
func PostFile(uri string, data *map[string]string, files *map[string]string) ([]byte, error) {
	body := &bytes.Buffer{}
	writer := multipart.NewWriter(body)

	// 普通数据
	for name, value := range *data {
		partWriter, _ := writer.CreateFormField(name)
		valueReader := bytes.NewReader([]byte(value))
		_, err := io.Copy(partWriter, valueReader)
		if err != nil {
			return nil, err
		}
	}

	// 文件数据
	for name, filePath := range *files {

		fileName := path.Base(filePath)

		fileWriter, _ := writer.CreateFormFile(name, fileName)
		fh, err := os.Open(filePath)
		if err != nil {
			return nil, err
		}
		defer fh.Close()

		_, err = io.Copy(fileWriter, fh)
		if err != nil {
			return nil, err
		}
	}

	// 发送请求
	response, err := http.Post(uri, writer.FormDataContentType(), body)

	//程序在使用完回复后必须关闭回复的主体。
	if response != nil {
		defer response.Body.Close()
	}

	// 请求错误
	if err != nil {
		return nil, err
	}

	return ioutil.ReadAll(response.Body)
}
