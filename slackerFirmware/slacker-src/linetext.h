#ifndef LINETEXT_H
#define LINETEXT_H
#include "listmodel.h"

class LineText : public ListItem
{
  Q_OBJECT

public:
  enum Roles
  {
    LineNumRole = Qt::UserRole+1,
    LineTextRole,  
    LineTextColorRole,
    LineTextAlignmentRole,
    LineTypeRole
  };

public:
  LineText(QObject *parent = 0): ListItem(parent) {}
  explicit LineText(const QString &lineNum, const QString &lineText, QObject *parent = 0,const QString &lineTextColor= "white",const QString &lineTextAlignment = "AlignLeft",const QString &lineType="lyric");

  QVariant data(int role) const;
  QHash<int, QByteArray> roleNames() const;

  inline QString lineNum() const { return m_LineNum; }
  inline QString lineText() const { return m_LineText; } 
  inline QString lineTextColor() const { return m_LineTextColor; }
  inline QString lineTextAlignment() const { return m_LineTextAlignment; }
  inline QString id() const { return m_LineType; }
  inline QString lineType() const { return m_LineType; }
  void setLineText(QString lineText);

private:

  QString m_LineNum;
  QString m_LineText;
  QString m_LineTextColor;
  QString m_LineTextAlignment;  //"AlignHCenter".AlignLeft
  QString m_LineType;
};

#endif // LINETEXT_H
