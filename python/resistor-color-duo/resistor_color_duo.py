def value(colors):
    pallete = [
            "black",
            "brown",
            "red",
            "orange",
            "yellow",
            "green",
            "blue",
            "violet",
            "grey",
            "white",
        ]

    return sum([pallete.index(color)*pow(10, 1-index) for index, color in enumerate(colors[:2])])

def value1(colors):
    pallete = [
            "black",
            "brown",
            "red",
            "orange",
            "yellow",
            "green",
            "blue",
            "violet",
            "grey",
            "white",
        ] 

    return int(str(pallete.index(colors[0])) + str(pallete.index(colors[1]))) 
