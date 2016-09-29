import QtQuick 2.0

Rectangle {

  id: screen
  x: 0; y:0
  width: 1920
  height: 1080
  color: "black"


  Item{
      id:errorIcon

      Image {
          id:errorIconImg
          source: "wait.png"
          width: 200
          height: 200
          x:400
          y:250

      }

      Text{
        id:errorTxt
        text:"Loading...";
        color:"white"
        font.family: "Courier 10 Pitch"
        font.pointSize: 32
        textFormat:Text.RichText
        x:650
        y:320
      }

}
  Item
  {
      id:autoscrollBoxMsg;
      visible: false;
      z: 99;
      x:350;
      y:250;

      Image
      {
          id:scrollImg
          source: "scroll.png"
          width: 567
          height: 300
          z: 100;
          x:0;
          y:0;
      }

      Text
      {
           id:autoscrollText
           text:"Active";
           color:"#2ed933"
           font.family: "Courier 10 Pitch"
           font.bold: true
           styleColor: "#fffffd" //white
            style: Text.Outline
           font.pointSize: 30
           textFormat:Text.RichText
           z: 100;
           y:160;
           x:0;
      }
  }


  Item
  {
      id:autoscrollBoxSpeedMsg;
      visible: false;
      y:10;
      x:1180;
      z:200;

      Text
      {
           id:autoscrolSpeedlText
           text:"0";
           color:"#eaf3f2"
           font.family: "Courier 10 Pitch"
           font.bold: true
           styleColor: "#fffffd" //white
           style: Text.Outline
           font.pointSize: 40
           textFormat:Text.RichText
           y:15;
           x:100;
           z: 100;
      }

      Image
      {
          id:speedImg
          source: "Green_Arrow_Up.png"
          width: 80
          height: 80
          x:5;
          y:10;
          z: 100;
      }


      Rectangle {
          width: 170; height: 100
          color: "#ffffff"
          radius:  5;
          opacity:.3;
          z: 99;

      }
  }

  Timer {
          id: autoscrollTimer;
          interval: 2000;
          running: false;
          repeat: true
          onTriggered:advanceLine();
      }

  Timer {
          id: mtTimer
          interval: 10; running: false; repeat: false
          onTriggered:  errorIcon.visible = false;
      }

  Timer {
          id: autoScrollBoxTimer
          interval: 3000; running: false; repeat: false
          onTriggered: initAutoScroll();
      }


  Timer {
          id: autoScrollBoxTimerExit
          interval: 2000; running: false; repeat: false
          onTriggered:{ autoscrollBoxMsg.visible =false; }
      }


  Timer {
          id: autoScrollBoxSpeedChangeBox
          interval: 2000; running: false; repeat: false
          onTriggered:{ autoscrollBoxSpeedMsg.visible = false; }
      }


  function advanceLine()
  {
     var nextSectionIndex = slackerModel.getNextSectionLineNum(dataView.currentIndex);
     var endOfFileIndex = slackerModel.getEndofFileLineNum();

    if( (dataView.currentIndex+1 === nextSectionIndex) || (dataView.currentIndex===endOfFileIndex)  )
    {
        console.log("stop" );
        autoscrollTimer.stop();      
    }

    dataView.incrementCurrentIndex();
    dataView.positionViewAtIndex(dataView.currentIndex ,ListView.Beginning);
  }

    ListView
    {
        width: 1920
        height: 1080
        id: dataView
        anchors.fill: parent
        model: slackerModel
        snapMode:ListView.SnapOneItem
        highlightFollowsCurrentItem:true
        delegate: DummyDelegate{}   
        z: 0;
    }

    function updateFileStateChange(newState)
    {

        if(newState===0)
        {
            errorIconImg.source = "exclamationButton.png";
            errorIcon.visible = true;
            errorTxt.text = "No File Found";
            console.log("newFileState:No File Found" );
        }
        else if(newState===1)
        {
            errorIconImg.source = "wait.png";
            errorIcon.visible = true;
            errorTxt.text = "Loading...";
            console.log("newFileState:Loading" );
            autoscrollTimer.stop();          
        }
        else if(newState===2)//loaded
        {
            mtTimer.start();
            console.log("newFileState:Loaded" );
        }
         else if(newState===3)
        {
            errorIconImg.source = "exclamationButton.png";
            errorIcon.visible = true;
            errorTxt.text = "Error Loading File";
            console.log("newFileState:Error Loading File" );
        }
        else
        {
            console.log("newFileState:invalid" );
            errorIcon.visible =false;
        }

      console.log("newState",newState );
    }

  function updateStateChange(newState)
   {
        var newIndex = 0;
        var newPageY = 0;
        var currentIndex =0;
        var interval = 0;

        var screenHeight = (screen.height*.71);

        if(newState===0)//PAGE_UP
        {
            var contentY =  dataView.contentY - screenHeight;
            if(contentY<0)
            {
                contentY = 0;
            }

            dataView.contentY = contentY;

            //If the item is outside the visible area, -1 is returned,
            newIndex =  dataView.indexAt (0, contentY );
            console.log("newIndex ",newIndex);
            if(newIndex === -1 )
            {
                newIndex = 0;
                dataView.contentY = 0;
            }

            var prevSectionIndex = slackerModel.getPrevSectionLineNum(dataView.currentIndex);

            console.log("newIndex ",newIndex);
            console.log("prevSectionIndex ",prevSectionIndex);
            console.log("dataView.currentIndex ",dataView.currentIndex);

            if( (newIndex <= prevSectionIndex) && (dataView.currentIndex !== prevSectionIndex) )
            {
                console.log("updateStateChange - we are at the end of the current song,move to the next song\n\n");
                newIndex = prevSectionIndex;
            }

            dataView.currentIndex = newIndex ;
            dataView.positionViewAtIndex(newIndex ,ListView.Beginning);

            if(newIndex !== prevSectionIndex && newIndex !== 0)
            {
                dataView.incrementCurrentIndex();
                dataView.positionViewAtIndex(dataView.currentIndex ,ListView.Beginning);
            }

        }
        else if(newState===1)//PAGE_DOWN
        {
            newPageY = dataView.contentY + screenHeight;

            //If the item is outside the visible area, -1 is returned,
            newIndex =  dataView.indexAt (0, newPageY );
            var endOfFileIndex = slackerModel.getEndofFileLineNum();

            currentIndex =  dataView.indexAt (0, dataView.contentY );
            var nextSectionIndex = slackerModel.getNextSectionLineNum(currentIndex);

            if( (newIndex >= nextSectionIndex) && (currentIndex !== nextSectionIndex) )
            {
                if(nextSectionIndex !== 0 && nextSectionIndex !== -1 )//dont loop back to the begining and there are more sections to move to
                {
                    newIndex = nextSectionIndex;
                }
            }

            dataView.currentIndex = newIndex ;
            dataView.positionViewAtIndex(newIndex ,ListView.Beginning);

        }
        else if(newState===2)//PREV_SECTION
        {            
            newIndex = slackerModel.getPrevSectionLineNum(dataView.currentIndex);
            if( newIndex !== -1)
            {
                dataView.positionViewAtIndex(newIndex,ListView.Beginning );
                dataView.currentIndex = newIndex;
            }
        }
        else if(newState===3)//NEXT_SECTION
        {
            newIndex = slackerModel.getNextSectionLineNum(dataView.currentIndex);
            dataView.positionViewAtIndex(newIndex,ListView.Beginning );
            dataView.currentIndex = newIndex;
        }
        else if(newState===4)//DEC_SPEED
        {
            if(autoscrollTimer.running)
            {
                interval =  autoscrollTimer.interval + 400;

                if(interval>5000)
                {                  
                    autoscrollTimer.interval = 5000;
                }
                else
                {
                    autoscrollTimer.interval = interval;
                }

                console.log("interval",autoscrollTimer.interval );

                autoScrollBoxSpeedChangeBox.stop();

                speedImg.source = "Red_Arrow_Down.png";
                autoscrollBoxSpeedMsg.visible=true;
                autoscrolSpeedlText.text= convertInterval(autoscrollTimer.interval) ;

                autoScrollBoxSpeedChangeBox.start();
            }

        }
        else if(newState===5)//INC_SPEED
        {
            interval = autoscrollTimer.interval - 400;

            if(interval < 1000)
            {
                autoscrollTimer.interval = 1000;
            }
            else
            {
                 autoscrollTimer.interval = interval;
            }

           console.log("INC_SPEED interval",autoscrollTimer.interval );

            if(!autoscrollTimer.running)
            {
                autoscrollTimer.start();
            }

            autoScrollBoxSpeedChangeBox.stop();

            speedImg.source = "Green_Arrow_Up.png";
            autoscrollBoxSpeedMsg.visible=true;
            autoscrolSpeedlText.text= convertInterval(autoscrollTimer.interval) ;

            autoScrollBoxSpeedChangeBox.start();

        }
        else if(newState===6)// START_AUTOSCROLL
        {

             console.log("START_AUTOSCROLL");
            if(!autoscrollTimer.running)
            {
                autoscrollText.text = "Activated"
                autoscrollText.x = 180;
                autoscrollText.color = "#2ed933";
                autoscrollText.styleColor = "#090908"

                autoscrollBoxMsg.visible = true;
                autoScrollBoxTimer.start();
            }

        }
        else if(newState===7)//STOP_AUTOSCROLL
        {
            if(autoscrollTimer.running)
            {
                autoscrollText.text = "Deactivated"
                autoscrollText.x = 160;

                autoscrollText.styleColor = "#fffffd" //white
                autoscrollText.color = "#fb0404";
                autoscrollBoxMsg.visible = true;
                autoscrollTimer.stop();
                autoScrollBoxTimerExit.start();
            }
        }
   }


    function convertInterval(interval)
    {
        var speed = "";

       //5000 == 1
       //1000 == 10

        speed = (((interval-1000) * -1) / 400) + 10;
        speed = Math.round(speed)

        console.log("speed:",speed );

        return speed;

    }

    function initAutoScroll()
    {
        autoscrollBoxMsg.visible = false;
        autoscrollTimer.start();
    }

}
