import QtQuick 2.0

Item {
    id: delegate
    implicitHeight:lineTextObj.implicitHeight
    width: 1350

    Text {

        id:lineNumTextObj
        text: lineNum
        width:30
        color:"white"
        font.family: "Helvetica"
        font.pointSize: 12
        horizontalAlignment:"AlignLeft"
        textFormat:Text.RichText
        y:lineTextObj.y+(lineTextObj.height/2)-(height/2)

    }

    property variant lineTextObj: lineTextObj
    Text
    {
        id:lineTextObj
        anchors.fill: parent;      
        color:lineTextColor
        font.family: "Helvetica"
        textFormat:Text.RichText
        anchors.left: lineNumTextObj.right
        anchors.leftMargin: 40
        horizontalAlignment:lineTextAlignment

        text: (lineType === "lyric") ? "   " + lineText : ""
    }

    Image {

        source: "stop.png"
        width: 200
        height: 200

        visible: (lineType === "lyric") ? false : true

        y:lineTextObj.y+lineTextObj.height
        x:600

    }

   // text: "   " + lineText
}
