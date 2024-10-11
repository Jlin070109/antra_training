namespace hw3;

public class MyStack<T>
{
    private List<T> _stack = new List<T>();

    public int Count()
    {
        return _stack.Count;
    }

    public T Pop()
    {
        if (_stack.Count == 0)
            throw new InvalidOperationException("Stack is empty.");

        T item = _stack[_stack.Count - 1];
        _stack.RemoveAt(_stack.Count - 1);
        return item;
    }

    public void Push(T item)
    {
        _stack.Add(item);
    }
}