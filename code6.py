import random

def guess_the_number():
    print("Welcome to Guess the Number")

    secret_number = random.randint(1, 100)
    attempts = 0

    while True:
        user_guess = int(input("Enter your guess (between 1 and 100): "))
        attempts += 1

        if user_guess == secret_number:
            print(f"Correct! You guessed the number in {attempts} attempts.")
            break
        elif user_guess < secret_number:
            print("Too Low! Try again.")
        else:
            print("Too High! Try again.")

if __name__ == "__main__":
    guess_the_number()
