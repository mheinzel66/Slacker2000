#include "linetext.h"

LineText::LineText(const QString &lineNum, const QString &lineText, QObject *parent,const QString &lineTextColor,const QString &lineTextAlignment,const QString &lineType) :
    ListItem(parent), m_LineNum(lineNum), m_LineText(lineText), m_LineTextColor(lineTextColor),m_LineTextAlignment(lineTextAlignment),m_LineType(lineType)
{
}

void LineText::setLineText(QString lineText)
{
  if(m_LineText != lineText)
  {
    m_LineText = lineText;
    emit dataChanged();
  }
}

QHash<int, QByteArray> LineText::roleNames() const
{
  QHash<int, QByteArray> names;
  names[LineNumRole] = "lineNum";
  names[LineTextRole] = "lineText";  
  names[LineTextColorRole] = "lineTextColor";
  names[LineTextAlignmentRole] = "lineTextAlignment";
  names[LineTypeRole] = "lineType";

  return names;
}

QVariant LineText::data(int role) const
{
  switch(role)
  {
  case LineNumRole:
    return lineNum();
  case LineTextRole:
    return lineText(); 
  case LineTextColorRole:
    return lineTextColor();
  case LineTextAlignmentRole:
    return lineTextAlignment();
  case LineTypeRole:
    return lineType();
  default:
    return QVariant();
  }
}
