def is_pangram(sentence):
    alphabet = set("abcdefghijklmnopqrstuvwxyz")

    return len(alphabet.difference(sentence.lower())) == 0
