# customized-base64
base64 encoding encode binary data to string for sending the binary data over string-formated network.
You can test [base64 encoding](https://www.base64decode.org/) and [base64 decoding](https://www.base64encode.org/)
The table used in base64 encoding can be shown in [base64 wiki](https://en.wikipedia.org/wiki/Base64)

Customized base64 encoding uses little modified table as below.
All of others except the table are same with base64 encoding.

## Encoding table

| 6-bits value | converted string |
|---|---|
| 0~25 | a~z |
| 26~51 | A~Z |
| 52~61 | 0~9 |
| 62 | + |
| 63 | / |

## Input
Some binary file can be used as input.
In order to execute customized-base64 encoding, the filename will be passed as an argument of a compiled program.

```
./app binary.bin
```

## Output
String or string formated file can be output.
For example, we assumes there is a file with 16-radix hex data as below

```
 04 20 c4
```

On converting into binary format, the above example is `0000 0100 0010 0000 1100 0100`. 
We can also re-arrange the binary form into 6-bits sequence,`000001 000010 000011 000100`.
And the 6-bits sequence means `1 2 3 4` in 10-radix manner.
Afterthat, it can be converted into string format with the modified encoding table.

Finally we will obtain `bcde`.
