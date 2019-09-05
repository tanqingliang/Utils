package Utils

import (
	"os"
	"path"
	"strings"
)

// 判断是否图片
// fileName 文件名
func IsImageFile(fileName string) bool {

	// 获取后缀名
	ext := path.Ext(fileName)

	// 转小写
	ext = strings.ToLower(ext)

	// 判断
	switch ext {
	case ".png", ".jpg", ".jpeg", ".gif", ".bmp":
		return true
	default:
		return false
	}
}

// 判断是否视频
// fileName 文件名
func IsVideoFile(fileName string) bool {

	// 获取后缀名
	ext := path.Ext(fileName)

	// 转小写
	ext = strings.ToLower(ext)

	// 转小写
	ext = strings.ToLower(ext)

	// 判断
	switch ext {
	case ".flv", ".swf", ".mkv", ".avi", ".rm", ".rmvb", ".mpeg", ".mpg", ".ogg", ".ogv", ".mov", ".wmv", ".mp4", ".webm", ".mp3", ".wav", ".mid":
		return true
	default:
		return false
	}
}

// 文件路径是否存在
// filePath 文件地址
func ExistPath(filePath string) bool {
	_, err := os.Stat(filePath)
	if err != nil {

		if os.IsExist(err) {
			return true
		}
		if os.IsNotExist(err) {
			return false
		}

		return false
	}
	return true
}

// 创建目录
// dirPath 目录地址
func CreateDirPath(dirPath string) error {
	if !ExistPath(dirPath) {
		return os.MkdirAll(dirPath, os.ModePerm)
	} else {
		return nil
	}
}
