
#include "listmodel.h"
#include <QDebug>

const char* COLUMN_NAMES[] = {
 "lineNum",
 "lineText",
 "lineTextColor",
 "lineTextAlignment",
  "lineType",
 NULL
};


ListModel::ListModel(ListItem* prototype, QObject *parent) :
    QAbstractListModel(parent), m_prototype(prototype)
{

}

QHash<int, QByteArray> makeRoleNames()
{
    int idx = 0;
    QHash<int, QByteArray> roleNames;
    while( COLUMN_NAMES[idx])
    {
          roleNames[Qt::UserRole + idx + 1] = COLUMN_NAMES[idx];
          idx++;
    }
    return roleNames;
}


QHash<int, QByteArray> ListModel::roleNames() const
{
    static const QHash<int, QByteArray> roleNames = makeRoleNames();
    return roleNames;
}

int ListModel::rowCount(const QModelIndex &parent) const
{
  Q_UNUSED(parent);
  return m_list.size();
}

QVariant ListModel::data(const QModelIndex &index, int role) const
{
  if(index.row() < 0 || index.row() >= m_list.size())
    return QVariant();
  return m_list.at(index.row())->data(role);
}

ListModel::~ListModel() {
  delete m_prototype;
  clear();
}

void ListModel::appendRow(ListItem *item)
{
  appendRows(QList<ListItem*>() << item);
}

void ListModel::appendRows(const QList<ListItem *> &items)
{
  beginInsertRows(QModelIndex(), rowCount(), rowCount()+items.size()-1);
  foreach(ListItem *item, items) {
    connect(item, SIGNAL(dataChanged()), SLOT(handleItemChange()));
    m_list.append(item);
  }
  endInsertRows();
}

void ListModel::insertRow(int row, ListItem *item)
{
  beginInsertRows(QModelIndex(), row, row);
  connect(item, SIGNAL(dataChanged()), SLOT(handleItemChange()));
  m_list.insert(row, item);
  endInsertRows();
}

void ListModel::handleItemChange()
{
  ListItem* item = static_cast<ListItem*>(sender());
  QModelIndex index = indexFromItem(item);
  if(index.isValid())
    emit dataChanged(index, index);
}

ListItem * ListModel::find(const QString &id) const
{
  foreach(ListItem* item, m_list) {
    if(item->id() == id) return item;
  }
  return 0;
}

QModelIndex ListModel::indexFromItem(const ListItem *item) const
{
  Q_ASSERT(item);
  for(int row=0; row<m_list.size(); ++row) {
    if(m_list.at(row) == item) return index(row);
  }
  return QModelIndex();
}

void ListModel::clear() 
{
    qDebug() << "void ListModel::clear()";

    int count =  m_list.size();

    beginRemoveRows(QModelIndex(), 0, count-1);
    for(int i=0; i<count; ++i)
    {
        // qDebug() << "ListModel::clear() :" << i;
        delete m_list.takeAt(0);
    }

    endRemoveRows();

}

bool ListModel::removeRow(int row, const QModelIndex &parent)
{
  Q_UNUSED(parent);
  if(row < 0 || row >= m_list.size()) return false;
  beginRemoveRows(QModelIndex(), row, row);
  delete m_list.takeAt(row);
  endRemoveRows();
  return true;
}

bool ListModel::removeRows(int row, int count, const QModelIndex &parent)
{
  Q_UNUSED(parent);
  if(row < 0 || (row+count) >= m_list.size()) return false;
  beginRemoveRows(QModelIndex(), row, row+count-1);
  for(int i=0; i<count; ++i) {
    delete m_list.takeAt(row);
  }
  endRemoveRows();
  return true;
}

ListItem * ListModel::takeRow(int row)
{
  beginRemoveRows(QModelIndex(), row, row);
  ListItem* item = m_list.takeAt(row);
  endRemoveRows();
  return item;
}
