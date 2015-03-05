using Akka.Actor;
using System;

namespace WinTail
{
	#region Program
	class Program
	{
		public static ActorSystem MyActorSystem;

		static void Main(string[] args)
		{
			// initialize MyActorSystem
			// YOU NEED TO FILL IN HERE
			MyActorSystem = ActorSystem.Create("MyActorSystem");

			// time to make your first actors!
			//YOU NEED TO FILL IN HERE
			// make consoleWriterActor using these props: Props.Create(() => new ConsoleWriterActor())
			// make consoleReaderActor using these props: Props.Create(() => new ConsoleReaderActor(consoleWriterActor))
			var consoleWriterProps = Props.Create(() => new ConsoleWriterActor());
			var consoleWriterActor = MyActorSystem.ActorOf(consoleWriterProps, "consoleWriterActor");

			Props tailCoordinatorProps = Props.Create(() => new TailCoordinatorActor());
			ActorRef tailCoordinatorActor = MyActorSystem.ActorOf(tailCoordinatorProps, "tailCoordinatorActor");

			Props fileValidatorActorProps = Props.Create(() => new FileValidatorActor(consoleWriterActor));
            var validationActor = MyActorSystem.ActorOf(fileValidatorActorProps, "validationActor");

			var consoleReaderProps = Props.Create<ConsoleReaderActor>();
			var consoleReaderActor = MyActorSystem.ActorOf(consoleReaderProps, "consoleReaderProps");

			// tell console reader to begin
			//YOU NEED TO FILL IN HERE
			consoleReaderActor.Tell(ConsoleReaderActor.StartCommand);
			// blocks the main thread from exiting until the actor system is shut down
			MyActorSystem.AwaitTermination();
		}
	}
	#endregion
}
