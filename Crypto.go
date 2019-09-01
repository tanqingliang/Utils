package Utils

import (
	"bytes"
	"crypto/aes"
	"crypto/cipher"
	"crypto/hmac"
	"crypto/md5"
	"crypto/sha1"
	"crypto/sha256"
	"crypto/sha512"
	"errors"
	"fmt"
	"hash"
	"io"
	"strings"
)

// Hash -> Md5 加密
// input 加密的内容
func HashMd5(input string) (string, error) {
	return HashEncrypt(md5.New(), input)
}

// Hash -> Sha 加密
// input 加密的内容
// bit 加密的位数 (1,256,512)
func HashSha(input string, bit int) (string, error) {

	switch bit {
	case 512:
		return HashEncrypt(sha512.New(), input)

	case 256:
		return HashEncrypt(sha256.New(), input)

	case 1:
		return HashEncrypt(sha1.New(), input)

	default:
		return "", errors.New("bit error")

	}
}

// Hash -> HmacSha 加密
// input 加密的内容
// bit 加密的位数 (1,256,512)
func HashHmacSha(input string, key string, bit int) (string, error) {

	// 判断key值不能为空
	if key == "" {
		return "", errors.New("Key cannot be empty")
	}

	// 转换key为字节
	keyByte := []byte(key)

	switch bit {
	case 512:
		return HashEncrypt(hmac.New(sha512.New, keyByte), input)

	case 256:
		return HashEncrypt(hmac.New(sha256.New, keyByte), input)

	case 1:
		return HashEncrypt(hmac.New(sha1.New, keyByte), input)

	default:
		return "", errors.New("bit error")

	}
}

// hash 加密
// h 加密方法
// input 加密的内容
func HashEncrypt(h hash.Hash, input string) (string, error) {

	// 判断加密内容不能为空
	if input == "" {
		return "", errors.New("content can not be blank")
	}

	// 加密
	_, err := io.WriteString(h, input)
	if err != nil {
		return "", err
	}

	// 输出
	return fmt.Sprintf("%x", h.Sum(nil)), nil
}

// Aes 加密模式
const (
	AesCBC = "cbc"
	AesCFB = "cfb"
	AesECB = "ecb"
)

// Aes CBC 加密
// input 加密的内容
// key 加密秘钥
// key 加密向量
func AesCBCEncrypt(input, key, iv []byte) ([]byte, error) {
	return AesEncrypt(input, key, iv, AesCBC, true)
}

// Aes CFB 加密
// input 加密的内容
// key 加密秘钥
// key 加密向量
func AesCFBEncrypt(input, key, iv []byte) ([]byte, error) {
	return AesEncrypt(input, key, iv, AesCFB, true)
}

// Aes ECB 加密
// input 加密的内容
// key 加密秘钥
// key 加密向量
func AesECBEncrypt(input, key, iv []byte) ([]byte, error) {
	return AesEncrypt(input, key, iv, AesECB, true)
}

// Aes 加密
// input 加密的内容
// key 加密秘钥
// key 加密向量
// mode 加密模式 （cbc,cfb,ecb）
// pkcs7 是否数据填充
func AesEncrypt(input, key, iv []byte, mode string, pkcs7 bool) ([]byte, error) {

	if input == nil {
		return nil, errors.New("content can not be blank")
	}
	if key == nil {
		return nil, errors.New("Key cannot be empty")
	}

	// 创建加密算法
	block, err := aes.NewCipher(key)
	if err != nil {
		return nil, err
	}

	// 秘钥块的长度
	blockSize := block.BlockSize()

	// 默认向量
	if iv == nil {
		iv = key[:blockSize]
	}

	// 判断向量长度
	if len(iv) < blockSize {
		return nil, errors.New("IV length must equal block size")
	}

	// 数据填充
	if pkcs7 {
		input = PKCS7Padding(input, blockSize)
	}

	// 加密内容切片
	ciphertext := make([]byte, len(input))

	// 加密模式
	switch strings.ToLower(mode) {
	case AesCBC:
		blockMode := cipher.NewCBCEncrypter(block, iv)
		blockMode.CryptBlocks(ciphertext, input)

	case AesCFB:
		blockModeStream := cipher.NewCFBEncrypter(block, iv)
		blockModeStream.XORKeyStream(ciphertext, input)

	case AesECB:
		tmpData := make([]byte, blockSize)
		for len(input) > 0 {
			block.Encrypt(tmpData, input)
			input = (input)[blockSize:]
			ciphertext = append(ciphertext, tmpData...)
		}

	default:
		return nil, errors.New("encrypter mode error")
	}

	// 返回数据
	return ciphertext, nil

}

// Aes CBC 解密
// input 加密的内容
// key 加密秘钥
// key 加密向量
func AesCBCDecrypt(input, key, iv []byte) ([]byte, error) {
	return AesDecrypt(input, key, iv, AesCBC, true)
}

// Aes CFB 解密
// input 加密的内容
// key 加密秘钥
// key 加密向量
func AesCFBDecrypt(input, key, iv []byte) ([]byte, error) {
	return AesDecrypt(input, key, iv, AesCFB, true)
}

// Aes ECB 解密
// input 加密的内容
// key 加密秘钥
// key 加密向量
func AesECBDecrypt(input, key, iv []byte) ([]byte, error) {
	return AesDecrypt(input, key, iv, AesECB, true)
}

// Aes  解密
// input 加密的内容
// key 加密秘钥
// key 加密向量
// mode 加密模式 （cbc,cfb,ecb）
// pkcs7 是否去掉数据填充
func AesDecrypt(input, key, iv []byte, mode string, pkcs7 bool) ([]byte, error) {

	if input == nil {
		return nil, errors.New("content can not be blank")
	}
	if key == nil {
		return nil, errors.New("Key cannot be empty")
	}

	// 创建加密算法
	block, err := aes.NewCipher(key)
	if err != nil {
		return nil, err
	}

	// 秘钥块的长度
	blockSize := block.BlockSize()

	// 默认向量
	if iv == nil {
		iv = key[:blockSize]
	}

	// 判断向量长度
	if len(iv) < blockSize {
		return nil, errors.New("IV length must equal block size")
	}

	// 解密内容切片
	ciphertext := make([]byte, len(input))

	// 解密模式 -> 解密数据
	switch strings.ToLower(mode) {
	case AesCBC:
		blockMode := cipher.NewCBCDecrypter(block, iv)
		blockMode.CryptBlocks(ciphertext, input)

	case AesCFB:
		blockModeStream := cipher.NewCFBDecrypter(block, iv)
		blockModeStream.XORKeyStream(ciphertext, input)

	case AesECB:
		tmpData := make([]byte, blockSize)
		for len(input) > 0 {
			block.Decrypt(tmpData, input)
			input = (input)[blockSize:]
			ciphertext = append(ciphertext, tmpData...)
		}

	default:
		return nil, errors.New("encrypter mode error")
	}

	// 去掉填充
	if pkcs7 {
		ciphertext = PKCS7UnPadding(ciphertext)
	}
	// 返回数据
	return ciphertext, nil
}

//使用PKCS7进行填充
func PKCS7Padding(ciphertext []byte, blockSize int) []byte {
	padding := blockSize - len(ciphertext)%blockSize
	padtext := bytes.Repeat([]byte{byte(padding)}, padding)
	cipherdata := append(ciphertext, padtext...)
	return cipherdata
}

// 使用PKCS7去掉填充
func PKCS7UnPadding(origData []byte) []byte {
	length := len(origData)
	unpadding := int((origData)[length-1])
	cipherdata := (origData)[:(length - unpadding)]
	return cipherdata
}
