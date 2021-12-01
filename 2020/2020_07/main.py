import numpy as np


class Bag:
    def __init__(self, name, contains):
        self.name = name
        self.contains = contains


def readAndParseFile():
    with open("input.txt", "r") as file:
        text = file.read().split("\n")

    bags = []

    for line in text:
        line = line.split(" ")
        name = line[0] + " " + line[1]
        if line[4] == "no":
            bags.append(Bag(name, []))
            continue

        containedBags = [line[5] + " " + line[6]]
        count = 6
        while (len(line) > 7) & (len(line) > count + 4):
            containedBags.append(line[count + 3] + " " + line[count + 4])
            count += 4

        bags.append(Bag(name, containedBags))

    return bags


def containsShinyGold(currentBag, allBags):
    containedBags = currentBag.contains

    if len(containedBags) == 0:
        return False

    for bag in containedBags:
        if bag == "shiny gold":
            return True
        else:
            return containsShinyGold(list(filter(lambda x: x.name == bag, allBags)), allBags)


bagList = readAndParseFile()
count = 0

for bag in bagList:
    if containsShinyGold(bag, bagList):
        count += 1
        print(count)
