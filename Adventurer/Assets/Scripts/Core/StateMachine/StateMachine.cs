// ######################################################################
// StateMachine - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
using System.Collections.Generic;

namespace Project
{
    public class StateMachine
	{
		#region Internal State Field(s):
		private Dictionary<Type, List<Transition>> m_transitions = new Dictionary<Type, List<Transition>>();
		private List<Transition> m_currentTransitions = new List<Transition>();
		private List<Transition> m_anyTransitions = new List<Transition>();
		private static List<Transition> EmptyTransition = new List<Transition>(0);
		#endregion
		
		#region Properties:
		public IState CurrentState { get; private set; }
		#endregion
		
		#region Public API:
		public void Tick() 
		{
			var transition = GetTransition();

			if (transition != null)
			{
				SetState(transition.ToState);
			}

			CurrentState?.OnTick();
		}

		public void SetState(IState _state)
		{
			if (_state == CurrentState) { return; }

			CurrentState?.OnExit();

			CurrentState = _state;

			m_transitions.TryGetValue(CurrentState.GetType(), out m_currentTransitions);

			if (m_currentTransitions == null)
			{
				m_currentTransitions = EmptyTransition;
			}

			CurrentState.OnEnter();
		}

		public void AddTransition(IState _fromState, IState _toState, Func<bool> _predicate)
		{
			if (m_transitions.TryGetValue(_fromState.GetType(), out var transitions) == false)
			{
				transitions = new List<Transition>();
				m_transitions[_fromState.GetType()] = transitions;
			}

			transitions.Add(new Transition(_toState, _predicate));
		}

		public void AddAnyTransition(IState _state, Func<bool> _predicate)
		{
			m_anyTransitions.Add(new Transition(_state, _predicate));
		}
		#endregion

		#region Internally Used Method(s):
		private Transition GetTransition()
		{
			foreach (var transition in m_anyTransitions)
			{
				if (transition.Condition()) { return transition; }
			}

			foreach (var transition in m_currentTransitions)
			{
				if (transition.Condition()) { return transition; }
			}

			return null;
		}
		#endregion

		#region Support Class(es):
		public class Transition
		{
			public readonly IState ToState;
			public readonly Func<bool> Condition;

			public Transition(IState _toState, Func<bool> _condition)
			{
				ToState = _toState;
				Condition = _condition;
			}
		}
		#endregion
	}
}