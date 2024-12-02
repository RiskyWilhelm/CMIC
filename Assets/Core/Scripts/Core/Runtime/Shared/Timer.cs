using System;
using UnityEngine;

[Serializable]
public struct Timer : IEquatable<Timer>
{
	private static readonly System.Random randomizer = new();

	[SerializeField]
	private TimeType _tickType;

	[SerializeField]
	[Min(0f)]
	private float _tickSecond;

	[SerializeField]
	[Min(0f)]
	private float _currentSecond;

	public float CurrentSecond
	{
		get => _currentSecond;
		set => _currentSecond = value;
	}

	public bool HasEnded
		=> (_currentSecond == 0f);

	public TimeType TickType
	{
		get => _tickType;
		set => _tickType = value;
	}

	public float TickSecond
	{
		get => _tickSecond;
		set => _tickSecond = value;
	}


    // Initialize
    public Timer(float tickSecond, TimeType tickType = TimeType.Scaled)
    {
        this._tickSecond = tickSecond;
        this._currentSecond = tickSecond;
		this._tickType = tickType;
    }


	// Update
	/// <returns> true if timer has ended </returns>
	public bool Tick()
    {
		if (_currentSecond > 0f)
		{
			switch (_tickType)
			{
				case TimeType.Scaled:
				_currentSecond -= Time.deltaTime;
				break;

				case TimeType.Unscaled:
				_currentSecond -= Time.unscaledDeltaTime;
				break;
			}
		}
		
		if (_currentSecond <= 0f)
		{
			_currentSecond = 0f;
			return true;
		}

        return false;
    }

	public void Finish()
	{
		_currentSecond = 0f;
	}

	public void Reset()
    {
        _currentSecond = _tickSecond;
    }

	public void Randomize(float maxExclusiveSeconds)
	{
		_tickSecond = randomizer.NextFloat(0f, maxExclusiveSeconds);
	}

	/// <summary> Uses <see cref="_tickSecond"/> as max exclusive value </summary>
	public void Randomize()
		=> Randomize(_tickSecond);

	public override bool Equals(object obj)
	{
		return (obj is Timer timer)
				&& Equals(timer);
	}

	public bool Equals(Timer other)
	{
		return (_tickType, _currentSecond, _tickSecond) == (other._tickType, other._currentSecond, other._tickSecond);
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(_tickType, _currentSecond, _tickSecond);
	}

	public static bool operator ==(Timer left, Timer right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(Timer left, Timer right)
	{
		return !(left == right);
	}
}