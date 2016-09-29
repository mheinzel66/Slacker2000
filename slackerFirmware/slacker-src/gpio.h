#ifndef GPIO_H
#define GPIO_H

#define GPIO_2 2
#define GPIO_3 3

class Gpio
{
public:

    Gpio();
    void init_gpio();
    int read_gpio(int n);

private:
    void init_gpio_pin(int gpio);
    void init_gpio_reserve_pin(int gpio);
};

#endif // GPIO_H
