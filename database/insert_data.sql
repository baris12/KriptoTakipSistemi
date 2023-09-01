INSERT INTO exchanges(name) VALUES('binance');
----------------------------
INSERT INTO role VALUES('DEVELOPER', 1);
INSERT INTO role VALUES('ADMIN', 1);
INSERT INTO role VALUES('REGULAR_USER', 2);
INSERT INTO role VALUES('NONE', 3);
----------------------------
INSERT INTO users(first_name, last_name, email, password, role)
VALUES ('baris', 'akbas', 'baris@test.com', 'baris', 'DEVELOPER');

INSERT INTO users(first_name, last_name, email, password, role)
VALUES ('admin', 'admin', 'admin@test.com', 'admin', 'ADMIN');

INSERT INTO users(first_name, last_name, email, password, role)
VALUES ('abc', 'xyz', 'abc@test.com', 'abc', 'REGULAR_USER');
----------------------------

INSERT INTO favorite_symbols (user_id, symbol) SELECT id, 'btcusdt' FROM users WHERE email = 'baris@test.com';
INSERT INTO favorite_symbols (user_id, symbol) SELECT id, 'ethusdt' FROM users WHERE email = 'baris@test.com';

INSERT INTO favorite_symbols (user_id, symbol) SELECT id, 'btcusdt' FROM users WHERE email = 'admin@test.com';
INSERT INTO favorite_symbols (user_id, symbol) SELECT id, 'xrpusdt' FROM users WHERE email = 'admin@test.com';

INSERT INTO favorite_symbols (user_id, symbol) SELECT id, 'btcusdt' FROM users WHERE email = 'abc@test.com';
INSERT INTO favorite_symbols (user_id, symbol) SELECT id, 'ltcusdt' FROM users WHERE email = 'abc@test.com';
----------------------------
INSERT INTO alarm_validity_period VALUES('PERPETUAL');
INSERT INTO alarm_validity_period VALUES('ONE_TIME');

----------------------------
INSERT INTO alarm_condition VALUES('CROSS');
INSERT INTO alarm_condition VALUES('CROSS_UP');
INSERT INTO alarm_condition VALUES('CROSS_DOWN');
----------------------------

INSERT INTO screens(name) VALUES('NONE');
INSERT INTO screens(name) VALUES('DASHBOARD');
INSERT INTO screens(name) VALUES('ALARMS');
INSERT INTO screens(name) VALUES('ANALYSIS');
INSERT INTO screens(name) VALUES('TRADING');
INSERT INTO screens(name) VALUES('USER_SETTINGS');
INSERT INTO screens(name) VALUES('SYSTEM_SETTINGS');


----------------------------

INSERT INTO role_screen_relation(role, screen_name) VALUES('DEVELOPER', 'NONE');
INSERT INTO role_screen_relation(role, screen_name) VALUES('DEVELOPER', 'DASHBOARD');
INSERT INTO role_screen_relation(role, screen_name) VALUES('DEVELOPER', 'ALARMS');
INSERT INTO role_screen_relation(role, screen_name) VALUES('DEVELOPER', 'ANALYSIS');
INSERT INTO role_screen_relation(role, screen_name) VALUES('DEVELOPER', 'TRADING');
INSERT INTO role_screen_relation(role, screen_name) VALUES('DEVELOPER', 'USER_SETTINGS');
INSERT INTO role_screen_relation(role, screen_name) VALUES('DEVELOPER', 'SYSTEM_SETTINGS');

INSERT INTO role_screen_relation(role, screen_name) VALUES('ADMIN', 'NONE');
INSERT INTO role_screen_relation(role, screen_name) VALUES('ADMIN', 'DASHBOARD');
INSERT INTO role_screen_relation(role, screen_name) VALUES('ADMIN', 'ALARMS');
INSERT INTO role_screen_relation(role, screen_name) VALUES('ADMIN', 'ANALYSIS');
INSERT INTO role_screen_relation(role, screen_name) VALUES('ADMIN', 'TRADING');
INSERT INTO role_screen_relation(role, screen_name) VALUES('ADMIN', 'USER_SETTINGS');
INSERT INTO role_screen_relation(role, screen_name) VALUES('ADMIN', 'SYSTEM_SETTINGS');

INSERT INTO role_screen_relation(role, screen_name) VALUES('REGULAR_USER', 'NONE');
INSERT INTO role_screen_relation(role, screen_name) VALUES('REGULAR_USER', 'DASHBOARD');
INSERT INTO role_screen_relation(role, screen_name) VALUES('REGULAR_USER', 'ALARMS');
INSERT INTO role_screen_relation(role, screen_name) VALUES('REGULAR_USER', 'TRADING');
INSERT INTO role_screen_relation(role, screen_name) VALUES('REGULAR_USER', 'ANALYSIS');
INSERT INTO role_screen_relation(role, screen_name) VALUES('REGULAR_USER', 'USER_SETTINGS');

INSERT INTO role_screen_relation(role, screen_name) VALUES('NONE', 'NONE');
INSERT INTO role_screen_relation(role, screen_name) VALUES('NONE', 'DASHBOARD');
----------------------------

INSERT INTO trade_signal_source_types VALUES('price');
INSERT INTO trade_signal_source_types VALUES('indicator');
----------------------------
INSERT INTO price_indicator_parameter_types VALUES ('input');
INSERT INTO price_indicator_parameter_types VALUES ('output');
----------------------------

INSERT INTO trade_signal_sources VALUES('open', 'price');
INSERT INTO trade_signal_sources VALUES('high', 'price');
INSERT INTO trade_signal_sources VALUES('low', 'price');
INSERT INTO trade_signal_sources VALUES('close', 'price');
INSERT INTO trade_signal_sources VALUES('volume', 'price');


----------Example indicator adding query---------------
INSERT INTO price_indicators VALUES('relative_strength_index', 'rsi');
INSERT INTO price_indicator_parameters VALUES('relative_strength_index', 'length', 'input');
INSERT INTO price_indicator_parameters VALUES('relative_strength_index', 'rsi', 'output');
INSERT INTO trade_signal_sources VALUES('rsi', 'indicator');
----------------------------

