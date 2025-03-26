using System;
using System.Collections.Generic;
using System.Linq;

namespace BennerLogic
{
    public class Network
    {
        public List<Item> Itens;

        public Network(int arrayLength)
        {
            try
            {
                Itens = new List<Item>(arrayLength);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void AddItem(int id)
        {
            try
            {
                if (Itens.Any(item => item.Id == id))
                {
                    throw new Exception("Item already exists");
                }

                Itens.Add(new Item(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void Connect(int id, int idItemConnected)
        {
            try
            {
                if (!Itens.Any(item => item.Id == id) || !Itens.Any(item => item.Id == idItemConnected))
                {
                    throw new Exception("Item not found");
                }

                Itens.First(item => item.Id == id).FrontConnection = idItemConnected;
                Itens.First(item => item.Id == idItemConnected).BackConnection = id;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void Disconnect(int id, int idItemConnected)
        {
            try
            {
                if (!Itens.Any(item => item.Id == id) || !Itens.Any(item => item.Id == idItemConnected))
                {
                    throw new Exception("Item not found");
                }
                else if (Itens.First(item => item.Id == id).FrontConnection != idItemConnected && Itens.First(item => item.Id == id).BackConnection != idItemConnected)
                {
                    throw new Exception("Items are not connected");
                }

                Itens.First(item => item.Id == id).FrontConnection = -1;
                Itens.First(item => item.Id == idItemConnected).BackConnection = -1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public bool Query(int id1, int id2)
        {
            try
            {
                if (!Itens.Any(item => item.Id == id1) || !Itens.Any(item => item.Id == id2))
                {
                    throw new Exception("Item not found");
                }

                var visited = new HashSet<int>();
                return AreConnected(id1, id2, visited);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        private bool AreConnected(int currentId, int targetId, HashSet<int> visited)
        {
            try
            {
                if (currentId == targetId)
                {
                    return true;
                }

                visited.Add(currentId);

                var currentItem = Itens.FirstOrDefault(item => item.Id == currentId);

                if(currentItem == null)
                {
                    return false;
                }

                if (currentItem.FrontConnection != -1 && !visited.Contains(currentItem.FrontConnection))
                {
                    if (AreConnected(currentItem.FrontConnection, targetId, visited))
                    {
                        return true;
                    }
                }

                if (currentItem.BackConnection != -1 && !visited.Contains(currentItem.BackConnection))
                {
                    if (AreConnected(currentItem.BackConnection, targetId, visited))
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public int LevelConnection(int id1, int id2)
        {
            try
            {
                if (!Itens.Any(item => item.Id == id1) || !Itens.Any(item => item.Id == id2))
                {
                    throw new Exception("Item not found");
                }

                var visited = new HashSet<int>();
                int level = GetConnectionLevel(id1, id2, visited);
                return level == -1 ? 0 : level;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        private int GetConnectionLevel(int currentId, int targetId, HashSet<int> visited)
        {
            try
            {
                if (currentId == targetId)
                {
                    return 0;
                }

                visited.Add(currentId);

                var currentItem = Itens.FirstOrDefault(item => item.Id == currentId);

                if (currentItem == null)
                {
                    return -1;
                }

                if (currentItem.FrontConnection != -1 && !visited.Contains(currentItem.FrontConnection))
                {
                    int level = GetConnectionLevel(currentItem.FrontConnection, targetId, visited);
                    if (level != -1)
                    {
                        return level + 1;
                    }
                }

                if (currentItem.BackConnection != -1 && !visited.Contains(currentItem.BackConnection))
                {
                    int level = GetConnectionLevel(currentItem.BackConnection, targetId, visited);
                    if (level != -1)
                    {
                        return level + 1;
                    }
                }

                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
