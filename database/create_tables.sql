CREATE TABLE exchanges(
	name VARCHAR(50) PRIMARY KEY
);
CREATE TABLE role(
	definition VARCHAR(50) PRIMARY KEY,
	rank INT NOT NULL
);

CREATE TABLE users(
	id SERIAL PRIMARY KEY,
	first_name VARCHAR(50),
	last_name VARCHAR(50),
	email VARCHAR(100) UNIQUE,
	password VARCHAR(50),
	role VARCHAR(50),
	CONSTRAINT fk_privilege
		FOREIGN KEY (role)
		REFERENCES role (definition)
);


CREATE TABLE favorite_symbols(
	id SERIAL PRIMARY KEY,
	user_id SERIAL NOT NULL,
	symbol VARCHAR(15) NOT NULL,
	CONSTRAINT fk_user
		FOREIGN KEY (user_id)
		REFERENCES users (id)
		ON DELETE CASCADE
);

CREATE TABLE alarm_validity_period(
	validity_period VARCHAR PRIMARY KEY
);
CREATE TABLE alarm_condition(
	condition VARCHAR PRIMARY KEY
);
CREATE TABLE price_alarms(
	id SERIAL PRIMARY KEY,
	user_id SERIAL NOT NULL,
	symbol VARCHAR(15) NOT NULL,
	price NUMERIC NOT NULL,
	validity_period VARCHAR NOT NULL REFERENCES alarm_validity_period(validity_period),
	condition VARCHAR NOT NULL REFERENCES alarm_condition(condition),
	active BOOLEAN NOT NULL,
	removed BOOLEAN NOT NULL,
	creation_time TIMESTAMP DEFAULT current_timestamp,
	CONSTRAINT fk_user
		FOREIGN KEY (user_id)
		REFERENCES users (id)
		ON DELETE CASCADE,
	CONSTRAINT uq_alarm_symbol_price UNIQUE (symbol, price)
);


CREATE TABLE api_keys(
	public_key VARCHAR(200),
	secret_key VARCHAR(200),
	exchange VARCHAR(50),
	user_id SERIAL,
	CONSTRAINT fk_exchange
		FOREIGN KEY (exchange)
		REFERENCES exchanges(name)
		ON DELETE CASCADE,
	CONSTRAINT fk_user
		FOREIGN KEY (user_id)
		REFERENCES users (id)
		ON DELETE CASCADE
);

CREATE TABLE screens(
	name VARCHAR(50) PRIMARY KEY
);

CREATE TABLE role_screen_relation(
    role VARCHAR(50),
    screen_name VARCHAR(50),
    CONSTRAINT fk_privilege_relation
        FOREIGN KEY (role)
        REFERENCES role (definition),
    CONSTRAINT fk_screen_relation
        FOREIGN KEY (screen_name)
        REFERENCES screens (name),
    PRIMARY KEY (role, screen_name)
);



CREATE TABLE trade_signal_source_types(
	type VARCHAR PRIMARY KEY
);-- there are two types of source type: price, indicator

CREATE TABLE price_indicator_parameter_types(
	type VARCHAR PRIMARY KEY
); -- there are two types: input, output

CREATE TABLE trade_signal_type(
	type VARCHAR PRIMARY KEY
); -- there are two type of trade signals: common and user_defined

CREATE TABLE trade_signal_sources(
	name VARCHAR PRIMARY KEY,
	type VARCHAR REFERENCES trade_signal_source_types(type)
);


CREATE TABLE price_indicators(
	name VARCHAR PRIMARY KEY,
	short_name VARCHAR NOT NULL UNIQUE
);

CREATE TABLE price_indicator_parameters(
	indicator_name VARCHAR REFERENCES price_indicators(name),
	parameter_name VARCHAR NOT NULL,
	type VARCHAR REFERENCES price_indicator_parameter_types(type),
	PRIMARY KEY (parameter_name, indicator_name)
); -- this is for only definition. later, users will be able to define their own indicators with this structure of data.

CREATE TABLE trade_signals(
	id SERIAL PRIMARY KEY,
	type VARCHAR REFERENCES trade_signal_type(type),
	name VARCHAR NOT NULL UNIQUE,
	source1 VARCHAR REFERENCES trade_signal_sources(name),
	source2 VARCHAR REFERENCES trade_signal_sources(name)
);