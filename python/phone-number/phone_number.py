import re

class PhoneNumber:
    number_pattern = r'^[2-9]\d\d[2-9]\d{5}'

    def __init__(self, number: str):
        self.number = ''.join([c for c in number if c.isdigit()])

        if len(self.number) == 11 and self.number[0] == '1':
            self.number = self.number[1:]

        if not re.match(PhoneNumber.number_pattern, self.number) or len(self.number) > 10:
            raise ValueError('The invalid argument.')

        self.area_code = self.number[:3]

    def pretty(self) -> str:
        return '('+self.number[:3]+')-'+self.number[3:6]+'-'+self.number[-4:]
