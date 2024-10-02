package main

import "fmt"

func main() {
    var threeD [3][5][2]int
    for i := 0; i < 3; i++ {
        for j := 0; j < 5; j++ {
            for k := 0; k < 2; k++ {
                threeD[i][j][k] = (i + 1) * (j + 1) * (k + 1)
            }
        }
    }
    fmt.Println("\nAll at once:", threeD)
}