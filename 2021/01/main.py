def readAndParseFile():
    with open("input.txt", "r") as file:
        text = file.read().split("\n")

    return text


insert = readAndParseFile()
sums = []
count = 0
for i in range(0, len(insert) - 2):
    sum = int(insert[i]) + int(insert[i+1]) + int(insert[i+2])
    sums.append(sum)

for i in range(1, len(sums)):
    if int(sums[i]) > int(sums[i - 1]):
        count += 1

print(count)
