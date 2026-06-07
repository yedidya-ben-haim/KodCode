import mysql.connector


conn = mysql.connector.connect(
    host="127.0.0.1",
    port=3306,
    user="root",
    password="secret"
)

cur = conn.cursor()


cur.execute("USE mydb")

crate_table = """
CREATE TABLE IF NOT EXISTS soldiers (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    `rank` VARCHAR(50),
    unit VARCHAR(50),
    active BOOLEAN DEFAULT TRUE
);
"""


cur.execute(crate_table)
conn.commit()
print("the table was created")


cur.close()
conn.close()



