import string
import random
class Robot:
    robot_names = {0:0}
    MAX_NAME_COUNT = 26 * 26 * 10 * 10 *10

    def __init__(self):
        self.Id = self.generate_id()
        self.name = self.translate_id2name(self.Id)

    def reset(self):
        self.Id = self.generate_id()
        self.name = self.translate_id2name(self.Id)

    def generate_id(self):
        tempID = 0
        while (Robot.robot_names.get(tempID) != None):
            tempID = random.randint(0, Robot.MAX_NAME_COUNT)
         
        self.Id = tempID
        Robot.robot_names[tempID] = tempID

        return tempID

    def translate_id2name(self, id):
        reversedName = [str((id//10**index)%10) for index, value in enumerate(range(3))]

        reversedName.append(string.ascii_uppercase[(id//(10*10*10)%26)])
        reversedName.append(string.ascii_uppercase[id//(10*10*10*26)])

        return ''.join(reversedName[::-1])
