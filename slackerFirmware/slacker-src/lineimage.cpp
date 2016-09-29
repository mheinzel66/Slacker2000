#include "lineimage.h"

LineImage::LineImage(const QString &lineNum, const QString &LineImage, QObject *parent,const QString &LineImageColor,const QString &LineImageAlignment,const QString &lineType) :
    ListItem(parent), m_LineNum(lineNum), m_LineImage(LineImage), m_LineImageColor(LineImageColor),m_LineImageAlignment(LineImageAlignment),m_LineType(lineType)
{
}

void LineImage::setLineImage(QString LineImage)
{
  if(m_LineImage != LineImage)
  {
    m_LineImage = LineImage;
    emit dataChanged();
  }
}

QHash<int, QByteArray> LineImage::roleNames() const
{
  QHash<int, QByteArray> names;
  names[LineNumRole] = "lineNum";
  names[LineImageRole] = "LineImage";
  names[LineImageColorRole] = "LineImageColor";
  names[LineImageAlignmentRole] = "LineImageAlignment";
  names[LineTypeRole] = "lineType";

  return names;
}

QVariant LineImage::data(int role) const
{
  switch(role)
  {
  case LineNumRole:
    return lineNum();
  case LineImageRole:
    return LineImage();
  case LineImageColorRole:
    return LineImageColor();
  case LineImageAlignmentRole:
    return LineImageAlignment();
  case LineTypeRole:
    return lineType();
  default:
    return QVariant();
  }
}
