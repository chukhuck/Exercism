class Matrix:
    def __init__(self, matrix_string: str):
        self.row_lenght = 0
        self.matrix_list = []

        for row in list(map(str.split, matrix_string.splitlines())):
            self.matrix_list.extend(list(map(int, row)))
            self.row_lenght = len(row)

    def row(self, index: int) -> list:
        return self.matrix_list[self.row_lenght * (index - 1):self.row_lenght * index]

    def column(self, index: int) -> list:
        return self.matrix_list[index - 1::self.row_lenght]
