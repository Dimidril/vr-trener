namespace Core.JointMechanic
{
    public static class ConnectedRequests
    {
        public static bool IsSocketsConnection(Connector connectorA, Connector connectorB)
        {
            if (connectorA.ConnectedConnector && connectorB.ConnectedConnector)
            {
                return connectorA.ConnectedConnector.ConnectedTube == connectorB.ConnectedConnector.ConnectedTube;
            }

            return false;
        }
    }
}