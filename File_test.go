package Utils

import (
	"fmt"
	"os"
	"testing"
)

var file1 = "1.jpg"
var file2 = "2.txt"
var file3 = "2.mp4"

func TestIsImageFile(t *testing.T) {

	fmt.Println(IsImageFile(file1))
	fmt.Println(IsImageFile(file2))
	fmt.Println(IsImageFile(file3))
}

func TestIsVideoFile(t *testing.T) {
	fmt.Println(IsVideoFile(file1))
	fmt.Println(IsVideoFile(file2))
	fmt.Println(IsVideoFile(file3))
}

func TestExistPath(t *testing.T) {
	fmt.Println(ExistPath(file1))
	fmt.Println(ExistPath("./File.go"))
}

func TestCreateDirPath(t *testing.T) {
	fmt.Println(CreateDirPath("./test"))
	os.Remove("./test")

}
