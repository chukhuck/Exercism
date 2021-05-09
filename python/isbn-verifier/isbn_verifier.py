

def is_valid(isbn: str) -> bool:
    clear_ISBN_in_hex = isbn.replace('-', '').replace('X', 'A')
    summary = sum([ int(i, base=16) * ( 10 - index) for i in clear_ISBN_in_hex]) 
    return summary % 11 
