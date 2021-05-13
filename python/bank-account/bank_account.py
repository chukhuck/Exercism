import threading

class BankAccount:
    
    def __init__(self):
        self.is_open = False
        self.balance = 0.0
        self.lock = threading.Lock()


    def get_balance(self):
        if not self.is_open:
            raise ValueError('The account is not openned')

        return self.balance

    def open(self):
        if self.is_open:
            raise ValueError('The account is openned yet.')
        else:
            self.is_open = True

    def deposit(self, amount):
        if not self.is_open:
            raise ValueError('The account is not openned')

        if amount < 0:
            raise ValueError('Incorrect value')

        self.lock.acquire()
        self.balance = self.balance + amount
        self.lock.release()

    def withdraw(self, amount):
        if not self.is_open:
            raise ValueError('The account is not openned')

        if self.balance < amount:
            raise ValueError('Sorry...you dont have that money.')

        if amount < 0:
            raise ValueError('Incorrect value')

        self.lock.acquire()
        self.balance = self.balance - amount
        self.lock.release()

    def close(self):
        if self.is_open:
            self.is_open = False
            self.balance = 0.0
        else:
            raise ValueError('The account is closed yet.')
