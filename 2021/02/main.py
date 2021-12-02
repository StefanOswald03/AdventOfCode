def readAndParseFile():
    with open("input.txt", "r") as file:
        text = file.read().split("\n")

    return text


input = readAndParseFile()

hori = 0
depth = 0
aim = 0

for line in input:
    line = line.split(" ")

    if line[0] == "forward":
        hori += int(line[1])
        depth += int(line[1])*aim
    elif line[0] == "down":
        aim += int(line[1])
    elif line[0] == "up":
        aim -= int(line[1])

print(hori * depth)