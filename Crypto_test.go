package Utils

import (
	"fmt"
	"testing"
)

func TestHash(t *testing.T) {

	// 加密内容
	input := "abcdefg"
	key := "12345678"

	data, err := HashMd5(input)
	fmt.Printf("\n HashMd5 \n %v -> %v \n error -> %v \n", input, data, err)

	data, err = HashSha(input, 1)
	fmt.Printf("\n HashSha1 \n %v -> %v \n error -> %v \n", input, data, err)

	data, err = HashSha(input, 256)
	fmt.Printf("\n HashSha256 \n %v -> %v \n error -> %v \n", input, data, err)

	data, err = HashSha(input, 512)
	fmt.Printf("\n HashSha512 \n %v -> %v \n error -> %v \n", input, data, err)

	data, err = HashHmacSha(input, key, 1)
	fmt.Printf("\n HashHmacSha1 \n %v -> %v \n error -> %v \n", input, data, err)

	data, err = HashHmacSha(input, key, 256)
	fmt.Printf("\n HashHmacSha256 \n %v -> %v \n error -> %v \n", input, data, err)

	data, err = HashHmacSha(input, key, 512)
	fmt.Printf("\n HashHmacSha512 \n %v -> %v \n error -> %v \n", input, data, err)

}

func TestAes(t *testing.T) {
	// 加密内容
	input := "abcdefg"
	key := "1234567812345612"
	iv := "1234567812345612"

	data, _ := AesCBCEncrypt([]byte(input), []byte(key), []byte(iv))
	fmt.Printf(" AesCBCEncrypt \t %v -> %v", input, Base64Encode(data))
	data, _ = AesCBCDecrypt(data, []byte(key), []byte(iv))
	fmt.Printf("\n AesCBCDecrypt \t %v -> %v", input, string(data))

	data, _ = AesCFBEncrypt([]byte(input), []byte(key), []byte(iv))
	fmt.Printf("\n\n AesCFBEncrypt \t %v -> %v", input, Base64Encode(data))
	data, _ = AesCFBDecrypt(data, []byte(key), []byte(iv))
	fmt.Printf("\n AesCFBDecrypt \t %v -> %v", input, string(data))

	data, _ = AesECBEncrypt([]byte(input), []byte(key), []byte(iv))
	fmt.Printf("\n\n AesECBEncrypt \t %v -> %v", input, Base64Encode(data))
	data, _ = AesECBDecrypt(data, []byte(key), []byte(iv))
	fmt.Printf("\n AesECBDecrypt \t %v -> %v", input, string(data))
}
