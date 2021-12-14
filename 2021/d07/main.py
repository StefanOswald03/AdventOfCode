def readAndParseFile():
    with open("input.txt", "r") as file:
        text = file.read().split("\n")

    return text[0].split(",")


numbers = readAndParseFile()

# print(int(2.5))

numbers = [int(x) for x in numbers]
numbers.sort()
#median = int(len(numbers) / 2) if len(numbers) % 2 == 0 else int(len(numbers)) + 1
#median =
#aim = numbers[median]
count = 0
Counts = []
print(max(numbers))

for aim in range(max(numbers)):
    print(aim)
    count = 0
    for number in numbers:

        diff = number - aim
        if diff < 0:
            diff *= -1

        summe = 0
        for i in range(1, diff + 1):
            summe += i

        count += summe

    Counts.append(count)


print(min(Counts))
