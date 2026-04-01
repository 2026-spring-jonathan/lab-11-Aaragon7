namespace labyrinth;

public record NodeLink(MazeCell From, string Direction, MazeCell To)
{

    public static List<NodeLink> ExploreMaze(MazeCell startingCell)
    {
        List<NodeLink> visitedNodes = new List<NodeLink>();
        exploreNode(startingCell, ref visitedNodes);

        return visitedNodes;
    }

    private static void exploreNode(MazeCell startingCell, ref List<NodeLink> visitedNodes)
    {
        if (startingCell == null) return;

        // Check each direction for a NodeLink that isn't null and hasn't been visited yet
        NodeLink newLink;

        if (startingCell.North != null)
        {
            newLink = new NodeLink(startingCell, "North", startingCell.North);
            if (visitedNodes.Contains(newLink) is false)
            {
                visitedNodes.Add(newLink);
                exploreNode(startingCell.North, ref visitedNodes);
            }
        }

        if (startingCell.East != null)
        {
            newLink = new NodeLink(startingCell, "East", startingCell.East);
            if (visitedNodes.Contains(newLink) is false)
            {
                visitedNodes.Add(newLink);
                exploreNode(startingCell.East, ref visitedNodes);
            }
        }

        if (startingCell.South != null)
        {
            newLink = new NodeLink(startingCell, "South", startingCell.South);
            if (visitedNodes.Contains(newLink) is false)
            {
                visitedNodes.Add(newLink);
                exploreNode(startingCell.South, ref visitedNodes);

            }
        }

        if (startingCell.West != null)
        {
            newLink = new NodeLink(startingCell, "West", startingCell.West);
            if (visitedNodes.Contains(newLink) is false)
            {
                visitedNodes.Add(newLink);
                exploreNode(startingCell.West, ref visitedNodes);
            }
        }

        return;
    }


    public string Label => $"{From.Id}[\"{From}\"]--{Direction}-->{To.Id}[\"{To}\"]";


}
