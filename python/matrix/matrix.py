class Matrix:
    def __init__(self, matrix_string: str):
        self.matrix_list = []

        for row in list(map(str.split, matrix_string.splitlines())):
            self.matrix_list.append(list(map(int, row)))

    def row(self, index: int) -> list():
        return self.matrix_list[index - 1]

    def column(self, index: int) -> list():
        return [row[index - 1] for row in self.matrix_list]
