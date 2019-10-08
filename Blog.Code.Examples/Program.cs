using System;
using AsyncBuilderWithParallelTasks;
using AsyncBuilderWithOrderedFuncOfTasks;
using AsyncBuilderWithCancellableTasks;

namespace Blog.Code.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ParallelTasksConsumer.Consume();
            OrderedTasksConsumer.Consume();
            CancellableTasksConsumer.Consume();
        }
    }
}
