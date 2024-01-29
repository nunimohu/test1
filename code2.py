import random
import string
import time

def generate_random_code():
    
    x_chars = ''.join(random.choices(string.ascii_uppercase + string.digits, k=16))
    
    
    code = f"RANDOMX RI-{x_chars[:4]}-{x_chars[4:8]}-{x_chars[8:12]}-{x_chars[12:16]} completed 10 ms"

    return code
    
def main():
    while True:
        
        random_code = generate_random_code()
        print(random_code)

        
        time.sleep(0.1)

if __name__ == "__main__":
    main()
