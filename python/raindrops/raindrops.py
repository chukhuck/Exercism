def convert(number) -> str:
    """
    Convert the number to PlingPlangPlong string

    The rules of `raindrops` are that if a given number:

    - has 3 as a factor, add 'Pling' to the result.
    - has 5 as a factor, add 'Plang' to the result.
    - has 7 as a factor, add 'Plong' to the result.
    - _does not_ have any of 3, 5, or 7 as a factor, the result should be the digits of the number.
    """
    raindrops = ''

    if number % 3 == 0:
        raindrops = raindrops + 'Pling'
    if number % 5 == 0:
        raindrops = raindrops + 'Plang'
    if number % 7 == 0:
        raindrops = raindrops + 'Plong'

    return str(number) if raindrops == '' else raindrops
