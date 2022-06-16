namespace Core.JointMechanic
{
    /// <summary>
    /// Класс для запросов касательно соединений
    /// </summary>
    public static class ConnectedRequests
    {
        /// <summary>
        /// Соединены ли 2 Connector по шлангу?
        /// </summary>
        /// <param name="connectorA"></param>
        /// <param name="connectorB"></param>
        /// <returns></returns>
        public static bool IsSocketsConnectionWithTube(Connector connectorA, Connector connectorB)
        {
            if (connectorA.ConnectedConnector && connectorB.ConnectedConnector)
            {
                return connectorA.ConnectedConnector.ConnectedTube == connectorB.ConnectedConnector.ConnectedTube;
            }

            return false;
        }

        /// <summary>
        /// Соединены ли 2 Connector
        /// </summary>
        /// <param name="connectorA"></param>
        /// <param name="connectorB"></param>
        /// <returns></returns>
        public static bool IsConnection(Connector connectorA, Connector connectorB)
        {
            return connectorA.ConnectedConnector == connectorB || connectorB.ConnectedConnector == connectorA;
        }
    }
}