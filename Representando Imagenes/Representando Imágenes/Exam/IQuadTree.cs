namespace Exam;

public enum QuadNodeColor
{
    White,
    Gray,
    Black,
}
public interface IQuadtree
{
    void DrawPixel(int x, int y, bool isBlack);
    int CountPixels();
    QuadNodeColor Color { get; }
    IQuadtree TopLeft { get; }
    IQuadtree TopRight { get; }
    IQuadtree BottomLeft { get; }
    IQuadtree BottomRight { get; }
}