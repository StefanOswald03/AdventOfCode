from datetime import datetime
from collections import defaultdict


def readAndParseFile():
    with open("input.txt", "r") as file:
        text = file.read().split("\n")

    result = []
    line = text[0].split(",")

    for number in line:
        result.append(int(number))

    return result


N = readAndParseFile()

X = defaultdict(int)
for n in N:
    if n not in X:
        X[n] = 0
    X[n] += 1

for day in range(256):
    #print(day, len(X))
    Y = defaultdict(int)
    for x, cnt in X.items():
        if x == 0:
            Y[6] += cnt
            Y[8] += cnt

        else:
            Y[x - 1] += cnt
    X = Y

print(sum(X.values()))
