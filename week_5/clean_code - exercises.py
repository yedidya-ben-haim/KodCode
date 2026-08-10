# region Exercise 1

MINIMUM_AGE = 18

def check_and_validate_user(users_list):
    validate_users = []
    for user in users_list:
        age = user[1]
        status = user[2]
        if age >= MINIMUM_AGE and status == "active":
            validate_users.append(user[0])
    return validate_users

user_list = [
            ["Dan", 25, "active"],
            ["Noa", 19, "active"],
            ["Yael", 30, "inactive"],
]
print(check_and_validate_user(user_list))

# endregion

# region Exercise 2

def check_user_email(user_email):
    if not user_email:
        print("Invalid user")
        return None
    else:
        return user_email

def check_quantity(quantity):
    if quantity <= 0 or quantity > stock:
        print("Invalid quantity")
        return None
    else:
        return quantity

def calculate_price(quantity, product_price):
    price = product_price * quantity
    if quantity >= 10:
        price *= 0.9
    if quantity >= 50:
        price *= 0.85
    return price

def update_quantity(quantity, stock):
    if quantity is not None:
        stock -= quantity
    return stock



def handle_purchase(user_email, product_name, product_price, stock, quantity):

    order_user = check_user_email(user_email)
    order_product = product_name
    order_quantity = check_quantity(quantity)
    stock = update_quantity(quantity, stock)
    order_total = calculate_price(quantity, product_price)
    order_status = "confirmed"
    print(f"Order {order_status}: {order_user} bought {order_quantity}x {order_product} for ${order_total}")
    return order_user, order_product, order_quantity, order_total, order_status

# endregion