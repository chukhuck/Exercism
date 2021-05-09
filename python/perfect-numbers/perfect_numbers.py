def classify(number):
    if number < 1:
        raise ValueError('the Number must be greater than 1.')

    summary = sum(get_factors(number))

    if summary == number:
        return 'perfect'
    elif summary > number:
        return 'abundant'
    else:
        return 'deficient'

def get_factors(number):
    return [i for i in range(1, number//2 + 1) if number%i == 0]
