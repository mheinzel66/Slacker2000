#include <stdlib.h>
#include "gpio.h"
#include <QDebug>
#include <fcntl.h>
#include <unistd.h>

#define MAX_BUF 255


//GPIO 2 pin3
//GPIO 3 pin 5

/////////////////////////////////////////
//Method:
/////////////////////////////////////////
Gpio::Gpio()
{
}

/////////////////////////////////////////
//Method:
/////////////////////////////////////////
int Gpio::read_gpio(int g)
{
    int fd;
    char value;
    char buf[MAX_BUF] ={0};
    sprintf(buf, "/sys/class/gpio/gpio%d/value", g);

    fd = open(buf, O_RDONLY);

    read(fd, &value, 1);
    close(fd);

    if(value == '0')
    {
        // Current GPIO status low
        return 0;
    }
    else
    {
        // Current GPIO status high
        return 1;
    }
}

/////////////////////////////////////////
//Method:
/////////////////////////////////////////
void Gpio::init_gpio_reserve_pin(int gpio)
{
    //Reserve (export) the GPIO:
    char buf[MAX_BUF] ={0};
    int fd = open("/sys/class/gpio/export", O_WRONLY);
    sprintf(buf, "%d", gpio);
    write(fd, buf, strlen(buf));
    close(fd);
}


/////////////////////////////////////////
//Method:
/////////////////////////////////////////
void Gpio::init_gpio_pin(int gpio)
{
    // Set up a memory regions to access GPIO
    init_gpio_reserve_pin(gpio);

    char buf[MAX_BUF] ={0};

    sprintf(buf, "/sys/class/gpio/gpio%d/direction", gpio);
    int fd = open(buf, O_WRONLY);

    // Set out direction
   // write(fd, "out", 3);

    // Set in direction
    write(fd, "in", 2);
    close(fd);
}

/////////////////////////////////////////
//Method:
/////////////////////////////////////////
void Gpio::init_gpio()
{
    init_gpio_pin(2);
    init_gpio_pin(3);
}
