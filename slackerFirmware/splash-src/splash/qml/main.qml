import QtQuick 2.0

Rectangle {
    x: 0; y:0
    width: 1920
    height: 1080
    color: "black"

    Image {

        sourceSize.width: 1360
        sourceSize.height: 1080
         source: "/etc/slacker/splash/bootsplash.png"
         x: 0
         y:0

     }

    AnimatedImage {
        id: animation;
        source: "/etc/slacker/splash/animation.gif"
        width: 1360
        x: 0
        y:740
    }

}



