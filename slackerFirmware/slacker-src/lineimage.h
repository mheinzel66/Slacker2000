#ifndef LineImage_H
#define LineImage_H
#include "listmodel.h"

class LineImage : public ListItem
{
  Q_OBJECT

public:
  enum Roles
  {
    LineNumRole = Qt::UserRole+1,
    LineImageRole,
    LineImageColorRole,
    LineImageAlignmentRole,
    LineTypeRole
  };

public:
  LineImage(QObject *parent = 0): ListItem(parent) {}
  explicit LineImage(const QString &lineNum, const QString &LineImage, QObject *parent = 0,const QString &LineImageColor= "white",const QString &LineImageAlignment = "AlignLeft",const QString &lineType="lyric");

  QVariant data(int role) const;
  QHash<int, QByteArray> roleNames() const;

  inline QString lineNum() const { return m_LineNum; }
  inline QString LineImage() const { return m_LineImage; }
  inline QString LineImageColor() const { return m_LineImageColor; }
  inline QString LineImageAlignment() const { return m_LineImageAlignment; }
  inline QString id() const { return m_LineType; }
  inline QString lineType() const { return id(); }
  void setLineImage(QString LineImage);

private:

  QString m_LineNum;
  QString m_LineImage;
  QString m_LineImageColor;
  QString m_LineImageAlignment;  //"AlignHCenter".AlignLeft
  QString m_LineType;
};

#endif // LineImage_H
