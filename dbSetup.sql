CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS cars(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  make TEXT NOT NULL,
  model TEXT NOT NULL,
  year INT NOT NULL,
  -- imgUrl TEXT,
  -- color TEXT,
  description TEXT,
  price DECIMAL(10, 2)
) default charset utf8;
CREATE TABLE IF NOT EXISTS houses(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  bedrooms INT NOT NULL,
  bathrooms INT NOT NULL,
  year INT NOT NULL,
  description TEXT,
  price DECIMAL(10, 2)
) default charset utf8;
/*CRUD*/
/*POST*/
INSERT INTO
  cars (make, model, year, description, price)
VALUES
  (
    "Bat",
    "Mobile",
    1961,
    "Holy spare tire, Batman!",
    10000
  );
INSERT INTO
  houses (bedrooms, bathrooms, year, description, price)
VALUES
  (
    10,
    4,
    1961,
    "Holy spare rooms, Batman!",
    100000
  );