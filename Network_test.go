package Utils

import (
	"fmt"
	"testing"
)

func TestGet(t *testing.T) {

	url := "https://www.baidu.com"

	body, err := Get(url)
	fmt.Println(string(body))

	fmt.Println(err.Error())

}
