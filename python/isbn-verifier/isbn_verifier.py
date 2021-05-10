import re

def is_valid(isbn: str) -> bool:
    isbn_pattern = r'^\d-?\d{3}-?\d{5}-?[\dX]$'

    if not re.match(isbn_pattern, isbn):
        return False

    clear_ISBN_in_hex = isbn.replace('-', '').replace('X', 'A')
    summary = sum([int(value, base=16) * ( 10 - index) for index, value in enumerate(clear_ISBN_in_hex)]) 
    return summary % 11 == 0
