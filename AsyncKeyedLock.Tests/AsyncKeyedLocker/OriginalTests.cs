using AsyncKeyedLock.Tests.Helpers;
using FluentAssertions;
using ListShuffle;
using System.Collections.Concurrent;
using Xunit;

namespace AsyncKeyedLock.Tests.AsyncKeyedLocker
{
    public class OriginalTests
    {
        [Fact]
        public void TestRecursion()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => { o.PoolSize = 1; o.PoolInitialFill = -1; });

            double Factorial(int number, bool isFirst = true)
            {
                using (asyncKeyedLocker.ConditionalLock("test123", isFirst))
                {
                    if (number == 0)
                        return 1;
                    return number * Factorial(number - 1, false);
                }
            }

            Assert.Equal(120, Factorial(5));
        }

        [Fact]
        public async Task TestRecursionAsync()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => o.PoolSize = 1);

            async Task<double> Factorial(int number, bool isFirst = true)
            {
                using (await asyncKeyedLocker.ConditionalLockAsync("test123", isFirst))
                {
                    if (number == 0)
                        return 1;
                    return number * await Factorial(number - 1, false);
                }
            }

            Assert.Equal(120, await Factorial(5));
        }

        [Fact]
        public void TestRecursionWithCancellationToken()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => o.PoolSize = 1);

            double Factorial(int number, bool isFirst = true)
            {
                using (asyncKeyedLocker.ConditionalLock("test123", isFirst, new CancellationToken(false)))
                {
                    if (number == 0)
                        return 1;
                    return number * Factorial(number - 1, false);
                }
            }

            Assert.Equal(120, Factorial(5));
        }

        [Fact]
        public async Task TestRecursionWithCancellationTokenAsync()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => o.PoolSize = 1);

            async Task<double> Factorial(int number, bool isFirst = true)
            {
                using (await asyncKeyedLocker.ConditionalLockAsync("test123", isFirst, new CancellationToken(false)))
                {
                    if (number == 0)
                        return 1;
                    return number * await Factorial(number - 1, false);
                }
            }

            Assert.Equal(120, await Factorial(5));
        }

        [Fact]
        public void TestRecursionWithTimeout()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>();

            double Factorial(int number, bool isFirst = true)
            {
                using (asyncKeyedLocker.ConditionalLock("test123", isFirst, Timeout.Infinite, out _))
                {
                    if (number == 0)
                        return 1;
                    return number * Factorial(number - 1, false);
                }
            }

            Assert.Equal(120, Factorial(5));
        }

        [Fact]
        public async Task TestRecursionWithTimeoutAsync()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>();

            async Task<double> Factorial(int number, bool isFirst = true)
            {
                using (await asyncKeyedLocker.ConditionalLockAsync("test123", isFirst, Timeout.Infinite))
                {
                    if (number == 0)
                        return 1;
                    return number * await Factorial(number - 1, false);
                }
            }

            Assert.Equal(120, await Factorial(5));
        }

        [Fact]
        public void TestRecursionWithTimeSpan()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => o.PoolSize = 1);

            double Factorial(int number, bool isFirst = true)
            {
                using (asyncKeyedLocker.ConditionalLock("test123", isFirst, TimeSpan.Zero, out _))
                {
                    if (number == 0)
                        return 1;
                    return number * Factorial(number - 1, false);
                }
            }

            Assert.Equal(120, Factorial(5));
        }

        [Fact]
        public async Task TestRecursionWithTimeSpanAsync()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => o.PoolSize = 1);

            async Task<double> Factorial(int number, bool isFirst = true)
            {
                using (await asyncKeyedLocker.ConditionalLockAsync("test123", isFirst, TimeSpan.Zero))
                {
                    if (number == 0)
                        return 1;
                    return number * await Factorial(number - 1, false);
                }
            }

            Assert.Equal(120, await Factorial(5));
        }

        [Fact]
        public void TestRecursionWithTimeoutAndCancellationToken()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => o.PoolSize = 1);

            double Factorial(int number, bool isFirst = true)
            {
                using (asyncKeyedLocker.ConditionalLock("test123", isFirst, Timeout.Infinite, new CancellationToken(false), out _))
                {
                    if (number == 0)
                        return 1;
                    return number * Factorial(number - 1, false);
                }
            }

            Assert.Equal(120, Factorial(5));
        }

        [Fact]
        public async Task TestRecursionWithTimeoutAndCancellationTokenAsync()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => o.PoolSize = 1);

            async Task<double> Factorial(int number, bool isFirst = true)
            {
                using (await asyncKeyedLocker.ConditionalLockAsync("test123", isFirst, Timeout.Infinite, new CancellationToken(false)))
                {
                    if (number == 0)
                        return 1;
                    return number * await Factorial(number - 1, false);
                }
            }

            Assert.Equal(120, await Factorial(5));
        }

        [Fact]
        public void TestRecursionWithTimeSpanAndCancellationToken()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => o.PoolSize = 1);

            double Factorial(int number, bool isFirst = true)
            {
                using (asyncKeyedLocker.ConditionalLock("test123", isFirst, TimeSpan.Zero, new CancellationToken(false), out _))
                {
                    if (number == 0)
                        return 1;
                    return number * Factorial(number - 1, false);
                }
            }

            Assert.Equal(120, Factorial(5));
        }

        [Fact]
        public async Task TestRecursionWithTimeSpanAndCancellationTokenAsync()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => o.PoolSize = 1);

            async Task<double> Factorial(int number, bool isFirst = true)
            {
                using (await asyncKeyedLocker.ConditionalLockAsync("test123", isFirst, TimeSpan.Zero, new CancellationToken(false)))
                {
                    if (number == 0)
                        return 1;
                    return number * await Factorial(number - 1, false);
                }
            }

            Assert.Equal(120, await Factorial(5));
        }

        [Fact]
        public void IsInUseRaceConditionCoverage()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => o.PoolSize = 1);
            var releaser = asyncKeyedLocker._dictionary._pool.GetObject("test");
            asyncKeyedLocker._dictionary._pool.PutObject(releaser);
            asyncKeyedLocker.Lock("test");
            releaser.IsNotInUse = true; // internal
            Assert.False(asyncKeyedLocker.IsInUse("test"));
            asyncKeyedLocker._dictionary.PoolingEnabled = false; // internal
            Assert.False(asyncKeyedLocker.IsInUse("test"));
        }

        [Fact]
        public void IsInUseKeyChangeRaceConditionCoverage()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => o.PoolSize = 1);
            var releaser = asyncKeyedLocker._dictionary._pool.GetObject("test");
            asyncKeyedLocker._dictionary._pool.PutObject(releaser);
            asyncKeyedLocker.Lock("test");
            releaser.Key = "test2"; // internal
            Assert.False(asyncKeyedLocker.IsInUse("test"));
            asyncKeyedLocker._dictionary.PoolingEnabled = false; // internal
            Assert.True(asyncKeyedLocker.IsInUse("test"));
        }

        [Fact]
        public void TryIncrementNoPoolingCoverage()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => o.PoolSize = 0);
            var releaser = (AsyncKeyedLockReleaser<string>)asyncKeyedLocker.Lock("test");
            releaser.IsNotInUse = true;
            var timer = new System.Timers.Timer(1000);
            timer.Elapsed += (_, _) => { releaser.Dispose(); };
            timer.Start();
            using (asyncKeyedLocker.Lock("test"))
            {
                Assert.True(asyncKeyedLocker.IsInUse("test"));
            }
            Assert.False(asyncKeyedLocker.IsInUse("test"));
        }

        [Fact]
        public void TestMaxCountLessThan1()
        {
            Action action = () =>
            {
                var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => { o.MaxCount = 0; o.PoolSize = 0; });
            };
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestMaxCount1ShouldNotThrow()
        {
            Action action = () =>
            {
                var asyncKeyedLocker = new AsyncKeyedLocker<string>(o =>
                {
                    o.MaxCount = 1;
                    o.PoolSize = 1;
                });
            };
            action.Should().NotThrow();
        }

        [Fact]
        public void TestComparerShouldBePossible()
        {
            Action action = () =>
            {
                var asyncKeyedLocker = new AsyncKeyedLocker<string>(EqualityComparer<string>.Default);
            };
            action.Should().NotThrow();
        }

        [Fact]
        public void TestComparerAndMaxCount1ShouldBePossible()
        {
            Action action = () =>
            {
                var asyncKeyedLocker = new AsyncKeyedLocker<string>(o =>
                {
                    o.MaxCount = 1;
                    o.PoolSize = 1;
                }, EqualityComparer<string>.Default);
            };
            action.Should().NotThrow();
        }

        [Fact]
        public void TestComparerAndMaxCount0ShouldNotBePossible()
        {
            Action action = () =>
            {
                var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => { o.MaxCount = 0; o.PoolSize = 0; }, EqualityComparer<string>.Default);
            };
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestConcurrencyLevelAndCapacityShouldBePossible()
        {
            Action action = () =>
            {
                var asyncKeyedLocker = new AsyncKeyedLocker<string>(Environment.ProcessorCount, 100);
            };
            action.Should().NotThrow();
        }

        [Fact]
        public void TestMaxCount0WithConcurrencyLevelAndCapacityShouldNotBePossible()
        {
            Action action = () =>
            {
                var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => { o.MaxCount = 0; o.PoolSize = 0; }, Environment.ProcessorCount, 100);
            };
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestConcurrencyLevelAndCapacityAndComparerShouldBePossible()
        {
            Action action = () =>
            {
                var asyncKeyedLocker = new AsyncKeyedLocker<string>(Environment.ProcessorCount, 100, EqualityComparer<string>.Default);
            };
            action.Should().NotThrow();
        }

        [Fact]
        public void TestMaxCount0AndConcurrencyLevelAndCapacityAndComparerShouldNotBePossible()
        {
            Action action = () =>
            {
                var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => { o.MaxCount = 0; o.PoolSize = 0; }, Environment.ProcessorCount, 100, EqualityComparer<string>.Default);
            };
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestMaxCount1AndConcurrencyLevelAndCapacityAndComparerShouldBePossible()
        {
            Action action = () =>
            {
                var asyncKeyedLocker = new AsyncKeyedLocker<string>(o =>
                {
                    o.MaxCount = 1;
                    o.PoolSize = 1;
                }, Environment.ProcessorCount, 100, EqualityComparer<string>.Default);
            };
            action.Should().NotThrow();
        }

        [Fact]
        public void TestDisposeDoesNotThrow()
        {
            Action action = () =>
            {
                var asyncKeyedLocker = new AsyncKeyedLocker<string>(o =>
                {
                    o.PoolSize = 20;
                    o.PoolInitialFill = 1;
                });
                asyncKeyedLocker.Lock("test");
                asyncKeyedLocker.Dispose();
            };
            action.Should().NotThrow();
        }

        [Fact]
        public void TestDisposeDoesNotThrowDespiteDisposedSemaphoreSlim()
        {
            Action action = () =>
            {
                var asyncKeyedLocker = new AsyncKeyedLocker<string>(o =>
                {
                    o.PoolSize = 20;
                    o.PoolInitialFill = 1;
                });
                AsyncKeyedLockReleaser<string> releaser = (AsyncKeyedLockReleaser<string>)asyncKeyedLocker.Lock("test");
                releaser.SemaphoreSlim.Dispose();
                asyncKeyedLocker.Dispose();
            };
            action.Should().NotThrow();
        }

        [Fact]
        public void TestIndexDoesNotThrow()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => { o.PoolSize = 0; });
            asyncKeyedLocker.Lock("test");
            asyncKeyedLocker.Index.Count.Should().Be(1);
            asyncKeyedLocker.Dispose();
        }

        [Fact]
        public void TestReadingMaxCount()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => { o.MaxCount = 2; o.PoolSize = 0; });
            asyncKeyedLocker.MaxCount.Should().Be(2);
        }

        [Fact]
        public void TestReadingMaxCountViaParameter()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>(new AsyncKeyedLockOptions(2, 0));
            asyncKeyedLocker.MaxCount.Should().Be(2);
        }

        [Fact]
        public void TestReadingMaxCountViaParameterWithComparer()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>(new AsyncKeyedLockOptions(2, 0), EqualityComparer<string>.Default);
            asyncKeyedLocker.MaxCount.Should().Be(2);
        }

        [Fact]
        public void TestReadingMaxCountViaParameterWithConcurrencyLevelAndCapacity()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>(new AsyncKeyedLockOptions(2, 0), Environment.ProcessorCount, 100);
            asyncKeyedLocker.MaxCount.Should().Be(2);
        }

        [Fact]
        public void TestReadingMaxCountViaParameterWithConcurrencyLevelAndCapacityAndComparer()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>(new AsyncKeyedLockOptions(2, 0), Environment.ProcessorCount, 100, EqualityComparer<string>.Default);
            asyncKeyedLocker.MaxCount.Should().Be(2);
        }

        [Fact]
        public void TestGetCurrentCount()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => { o.PoolSize = 0; });
            asyncKeyedLocker.GetRemainingCount("test").Should().Be(0);
            asyncKeyedLocker.GetCurrentCount("test").Should().Be(1);
            asyncKeyedLocker.Lock("test");
            asyncKeyedLocker.GetRemainingCount("test").Should().Be(1);
            asyncKeyedLocker.GetCurrentCount("test").Should().Be(0);
        }

        [Fact]
        public async Task TestTimeoutBasic()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => { o.PoolSize = 0; });
            using (var myLock = await asyncKeyedLocker.LockAsync("test", 0))
            {
                Assert.True(myLock.EnteredSemaphore);
                Assert.True(asyncKeyedLocker.IsInUse("test"));
            }
            Assert.False(asyncKeyedLocker.IsInUse("test"));
        }

        [Fact]
        public void TestTimeoutBasicWithOutParameter()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => { o.PoolSize = 0; });
            using (var myLock = asyncKeyedLocker.Lock("test", 0, out var entered))
            {
                Assert.True(entered);
                Assert.True(asyncKeyedLocker.IsInUse("test"));
            }
            Assert.False(asyncKeyedLocker.IsInUse("test"));
        }

        [Fact]
        public async Task TestTimeout()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => { o.PoolSize = 0; });
            using (await asyncKeyedLocker.LockAsync("test"))
            {
                using (var myLock = await asyncKeyedLocker.LockAsync("test", 0))
                {
                    Assert.False(myLock.EnteredSemaphore);
                }
                Assert.True(asyncKeyedLocker.IsInUse("test"));
            }
            Assert.False(asyncKeyedLocker.IsInUse("test"));
        }

        [Fact]
        public void TestTimeoutWithTimeSpanSynchronous()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => { o.PoolSize = 0; });
            using (asyncKeyedLocker.Lock("test"))
            {
                using (asyncKeyedLocker.Lock("test", TimeSpan.Zero, out bool entered))
                {
                    Assert.False(entered);
                }
                Assert.True(asyncKeyedLocker.IsInUse("test"));
            }
            Assert.False(asyncKeyedLocker.IsInUse("test"));
        }

        [Fact]
        public void TestTimeoutWithInfiniteTimeoutSynchronous()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => { o.PoolSize = 0; });
            using (asyncKeyedLocker.Lock("test", Timeout.Infinite, out bool entered))
            {
                Assert.True(entered);
                Assert.True(asyncKeyedLocker.IsInUse("test"));
            }
            Assert.False(asyncKeyedLocker.IsInUse("test"));
        }

        [Fact]
        public void TestTimeoutWithInfiniteTimeSpanSynchronous()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => { o.PoolSize = 0; });
            using (asyncKeyedLocker.Lock("test", TimeSpan.FromMilliseconds(Timeout.Infinite), out bool entered))
            {
                Assert.True(entered);
                Assert.True(asyncKeyedLocker.IsInUse("test"));
            }
            Assert.False(asyncKeyedLocker.IsInUse("test"));
        }

        [Fact]
        public async Task TestTimeoutWithTimeSpan()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => { o.PoolSize = 0; });
            using (await asyncKeyedLocker.LockAsync("test"))
            {
                using (var myLock = await asyncKeyedLocker.LockAsync("test", TimeSpan.Zero))
                {
                    Assert.False(myLock.EnteredSemaphore);
                }
                Assert.True(asyncKeyedLocker.IsInUse("test"));
            }
            Assert.False(asyncKeyedLocker.IsInUse("test"));
        }

        [Fact]
        public void TestTimeoutWithInfiniteTimeoutAndCancellationToken()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => { o.PoolSize = 0; });
            using (asyncKeyedLocker.Lock("test", Timeout.Infinite, new CancellationToken(false), out bool entered))
            {
                Assert.True(entered);
                Assert.True(asyncKeyedLocker.IsInUse("test"));
            }
            Assert.False(asyncKeyedLocker.IsInUse("test"));
        }

        [Fact]
        public void TestTimeoutWithZeroTimeoutAndCancellationToken()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => { o.PoolSize = 0; });
            using (asyncKeyedLocker.Lock("test", 0, new CancellationToken(false), out bool entered))
            {
                Assert.True(entered);
                Assert.True(asyncKeyedLocker.IsInUse("test"));
            }
            Assert.False(asyncKeyedLocker.IsInUse("test"));
        }

        [Fact]
        public void TestTimeoutWithZeroTimeoutAndCancelledToken()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => { o.PoolSize = 0; });
            Action action = () =>
            {
                asyncKeyedLocker.Lock("test", 0, new CancellationToken(true), out bool entered);
            };
            action.Should().Throw<OperationCanceledException>();
            asyncKeyedLocker.IsInUse("test").Should().BeFalse();
        }

        [Fact]
        public void TestTimeoutWithInfiniteTimeSpanAndCancellationToken()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => { o.PoolSize = 0; });
            using (asyncKeyedLocker.Lock("test", TimeSpan.FromMilliseconds(Timeout.Infinite), new CancellationToken(false), out bool entered))
            {
                Assert.True(entered);
                Assert.True(asyncKeyedLocker.IsInUse("test"));
            }
            Assert.False(asyncKeyedLocker.IsInUse("test"));
        }

        [Fact]
        public void TestTimeoutWithZeroTimeSpanAndCancellationToken()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => { o.PoolSize = 0; });
            using (asyncKeyedLocker.Lock("test", TimeSpan.FromMilliseconds(0), new CancellationToken(false), out bool entered))
            {
                Assert.True(entered);
                Assert.True(asyncKeyedLocker.IsInUse("test"));
            }
            Assert.False(asyncKeyedLocker.IsInUse("test"));
        }

        [Fact]
        public void TestTimeoutWithZeroTimeSpanAndCancelledToken()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => { o.PoolSize = 0; });
            Action action = () =>
            {
                asyncKeyedLocker.Lock("test", TimeSpan.FromMilliseconds(0), new CancellationToken(true), out bool entered);
            };
            action.Should().Throw<OperationCanceledException>();
            asyncKeyedLocker.IsInUse("test").Should().BeFalse();
        }

        [Fact]
        public void TestTimeoutTryLock()
        {
            var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => { o.PoolSize = 0; });
            using (asyncKeyedLocker.Lock("test"))
            {
                Assert.True(asyncKeyedLocker.IsInUse("test"));
                Assert.False(asyncKeyedLocker.TryLock("test", () => { }, 0, CancellationToken.None));
                Assert.False(asyncKeyedLocker.TryLock("test", () => { }, TimeSpan.Zero, CancellationToken.None));
            }
            Assert.False(asyncKeyedLocker.IsInUse("test"));
        }

        [Fact]
        public async Task BasicTest()
        {
            var locks = 5000;
            var concurrency = 50;
            var asyncKeyedLocker = new AsyncKeyedLocker<object>(o => { o.PoolSize = 0; });
            var concurrentQueue = new ConcurrentQueue<(bool entered, int key)>();

            var tasks = Enumerable.Range(1, locks * concurrency)
                .Select(async i =>
                {
                    var key = Convert.ToInt32(Math.Ceiling((double)i / concurrency));
                    using (await asyncKeyedLocker.LockAsync(key))
                    {
                        await Task.Delay(20);
                        concurrentQueue.Enqueue((true, key));
                        await Task.Delay(80);
                        concurrentQueue.Enqueue((false, key));
                    }
                });
            await Task.WhenAll(tasks.AsParallel());

            bool valid = concurrentQueue.Count == locks * concurrency * 2;

            var entered = new HashSet<int>();

            while (valid && !concurrentQueue.IsEmpty)
            {
                concurrentQueue.TryDequeue(out var result);
                if (result.entered)
                {
                    if (entered.Contains(result.key))
                    {
                        valid = false;
                        break;
                    }
                    entered.Add(result.key);
                }
                else
                {
                    if (!entered.Contains(result.key))
                    {
                        valid = false;
                        break;
                    }
                    entered.Remove(result.key);
                }
            }

            Assert.True(valid);
        }

        [Fact]
        public async Task BasicTestGenerics()
        {
            var locks = 5000;
            var concurrency = 50;
            var asyncKeyedLocker = new AsyncKeyedLocker<int>(o => { o.PoolSize = 0; });
            var concurrentQueue = new ConcurrentQueue<(bool entered, int key)>();

            var tasks = Enumerable.Range(1, locks * concurrency)
                .Select(async i =>
                {
                    var key = Convert.ToInt32(Math.Ceiling((double)i / concurrency));
                    using (await asyncKeyedLocker.LockAsync(key))
                    {
                        await Task.Delay(20);
                        concurrentQueue.Enqueue((true, key));
                        await Task.Delay(80);
                        concurrentQueue.Enqueue((false, key));
                    }
                });
            await Task.WhenAll(tasks.AsParallel());

            bool valid = concurrentQueue.Count == locks * concurrency * 2;

            var entered = new HashSet<int>();

            while (valid && !concurrentQueue.IsEmpty)
            {
                concurrentQueue.TryDequeue(out var result);
                if (result.entered)
                {
                    if (entered.Contains(result.key))
                    {
                        valid = false;
                        break;
                    }
                    entered.Add(result.key);
                }
                else
                {
                    if (!entered.Contains(result.key))
                    {
                        valid = false;
                        break;
                    }
                    entered.Remove(result.key);
                }
            }

            Assert.True(valid);
        }

        [Fact]
        public async Task BenchmarkSimulationTest()
        {
            AsyncKeyedLocker<string> AsyncKeyedLocker;
            ParallelQuery<Task>? AsyncKeyedLockerTasks = null;
            Dictionary<int, List<int>> _shuffledIntegers = new();

            var NumberOfLocks = 200;
            var Contention = 100;
            var GuidReversals = 0;

            if (!_shuffledIntegers.TryGetValue(Contention * NumberOfLocks, out var ShuffledIntegers))
            {
                ShuffledIntegers = Enumerable.Range(0, Contention * NumberOfLocks).ToList();
                ShuffledIntegers.Shuffle();
                _shuffledIntegers[Contention * NumberOfLocks] = ShuffledIntegers;
            }

            if (NumberOfLocks != Contention)
            {
                AsyncKeyedLocker = new AsyncKeyedLocker<string>(o => o.PoolSize = NumberOfLocks, Environment.ProcessorCount, NumberOfLocks);
                AsyncKeyedLockerTasks = ShuffledIntegers
                    .Select(async i =>
                    {
                        var key = i % NumberOfLocks;

                        using (var myLock = await AsyncKeyedLocker.LockAsync(key.ToString()))
                        {
                            for (int j = 0; j < GuidReversals; j++)
                            {
                                Guid guid = Guid.NewGuid();
                                var guidString = guid.ToString();
                                guidString = guidString.Reverse().ToString();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                                if (guidString.Length != 53)
                                {
                                    throw new Exception($"Not 53 but {guidString?.Length}");
                                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                            }
                        }

                        await Task.Yield();
                    }).AsParallel();

                await Task.WhenAll(AsyncKeyedLockerTasks);
            }
        }

        [Fact]
        public async Task BasicTestGenericsPooling50k()
        {
            var locks = 50_000;
            var concurrency = 50;
            var asyncKeyedLocker = new AsyncKeyedLocker<int>(o => o.PoolSize = 50_000, Environment.ProcessorCount, 50_000);
            var concurrentQueue = new ConcurrentQueue<(bool entered, int key)>();

            var tasks = Enumerable.Range(1, locks * concurrency)
                .Select(async i =>
                {
                    var key = Convert.ToInt32(Math.Ceiling((double)i / concurrency));
                    using (await asyncKeyedLocker.LockAsync(key))
                    {
                        await Task.Delay(20);
                        concurrentQueue.Enqueue((true, key));
                        await Task.Delay(80);
                        concurrentQueue.Enqueue((false, key));
                    }
                });
            await Task.WhenAll(tasks.AsParallel());

            bool valid = concurrentQueue.Count == locks * concurrency * 2;

            var entered = new HashSet<int>();

            while (valid && !concurrentQueue.IsEmpty)
            {
                concurrentQueue.TryDequeue(out var result);
                if (result.entered)
                {
                    if (entered.Contains(result.key))
                    {
                        valid = false;
                        break;
                    }
                    entered.Add(result.key);
                }
                else
                {
                    if (!entered.Contains(result.key))
                    {
                        valid = false;
                        break;
                    }
                    entered.Remove(result.key);
                }
            }

            Assert.True(valid);
        }

        [Fact]
        public async Task BasicTestGenericsPooling50kUnfilled()
        {
            var locks = 50_000;
            var concurrency = 50;
            var asyncKeyedLocker = new AsyncKeyedLocker<int>(o =>
                {
                    o.PoolSize = 50_000;
                    o.PoolInitialFill = 0;
                }, Environment.ProcessorCount, 50_000);
            var concurrentQueue = new ConcurrentQueue<(bool entered, int key)>();

            var tasks = Enumerable.Range(1, locks * concurrency)
                .Select(async i =>
                {
                    var key = Convert.ToInt32(Math.Ceiling((double)i / concurrency));
                    using (await asyncKeyedLocker.LockAsync(key))
                    {
                        await Task.Delay(20);
                        concurrentQueue.Enqueue((true, key));
                        await Task.Delay(80);
                        concurrentQueue.Enqueue((false, key));
                    }
                });
            await Task.WhenAll(tasks.AsParallel());

            bool valid = concurrentQueue.Count == locks * concurrency * 2;

            var entered = new HashSet<int>();

            while (valid && !concurrentQueue.IsEmpty)
            {
                concurrentQueue.TryDequeue(out var result);
                if (result.entered)
                {
                    if (entered.Contains(result.key))
                    {
                        valid = false;
                        break;
                    }
                    entered.Add(result.key);
                }
                else
                {
                    if (!entered.Contains(result.key))
                    {
                        valid = false;
                        break;
                    }
                    entered.Remove(result.key);
                }
            }

            Assert.True(valid);
        }

        [Fact]
        public async Task BasicTestGenericsPoolingProcessorCount()
        {
            var locks = 50_000;
            var concurrency = 50;
            var asyncKeyedLocker = new AsyncKeyedLocker<int>(o => o.PoolSize = Environment.ProcessorCount, Environment.ProcessorCount, 50_000);
            var concurrentQueue = new ConcurrentQueue<(bool entered, int key)>();

            var tasks = Enumerable.Range(1, locks * concurrency)
                .Select(async i =>
                {
                    var key = Convert.ToInt32(Math.Ceiling((double)i / concurrency));
                    using (await asyncKeyedLocker.LockAsync(key))
                    {
                        await Task.Delay(20);
                        concurrentQueue.Enqueue((true, key));
                        await Task.Delay(80);
                        concurrentQueue.Enqueue((false, key));
                    }
                });
            await Task.WhenAll(tasks.AsParallel());

            bool valid = concurrentQueue.Count == locks * concurrency * 2;

            var entered = new HashSet<int>();

            while (valid && !concurrentQueue.IsEmpty)
            {
                concurrentQueue.TryDequeue(out var result);
                if (result.entered)
                {
                    if (entered.Contains(result.key))
                    {
                        valid = false;
                        break;
                    }
                    entered.Add(result.key);
                }
                else
                {
                    if (!entered.Contains(result.key))
                    {
                        valid = false;
                        break;
                    }
                    entered.Remove(result.key);
                }
            }

            Assert.True(valid);
        }

        [Fact]
        public async Task BasicTestGenericsPooling10k()
        {
            var locks = 50_000;
            var concurrency = 50;
            var asyncKeyedLocker = new AsyncKeyedLocker<int>(o => o.PoolSize = 10_000, Environment.ProcessorCount, 50_000);
            var concurrentQueue = new ConcurrentQueue<(bool entered, int key)>();

            var tasks = Enumerable.Range(1, locks * concurrency)
                .Select(async i =>
                {
                    var key = Convert.ToInt32(Math.Ceiling((double)i / concurrency));
                    using (await asyncKeyedLocker.LockAsync(key))
                    {
                        await Task.Delay(20);
                        concurrentQueue.Enqueue((true, key));
                        await Task.Delay(80);
                        concurrentQueue.Enqueue((false, key));
                    }
                });
            await Task.WhenAll(tasks.AsParallel());

            bool valid = concurrentQueue.Count == locks * concurrency * 2;

            var entered = new HashSet<int>();

            while (valid && !concurrentQueue.IsEmpty)
            {
                concurrentQueue.TryDequeue(out var result);
                if (result.entered)
                {
                    if (entered.Contains(result.key))
                    {
                        valid = false;
                        break;
                    }
                    entered.Add(result.key);
                }
                else
                {
                    if (!entered.Contains(result.key))
                    {
                        valid = false;
                        break;
                    }
                    entered.Remove(result.key);
                }
            }

            Assert.True(valid);
        }

        [Fact]
        public async Task BasicTestGenericsString()
        {
            var locks = 5000;
            var concurrency = 50;
            var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => { o.PoolSize = 0; });
            var concurrentQueue = new ConcurrentQueue<(bool entered, string key)>();

            var tasks = Enumerable.Range(1, locks * concurrency)
                .Select(async i =>
                {
                    var key = Convert.ToInt32(Math.Ceiling((double)i / 5)).ToString();
                    using (await asyncKeyedLocker.LockAsync(key))
                    {
                        await Task.Delay(20);
                        concurrentQueue.Enqueue((true, key));
                        await Task.Delay(80);
                        concurrentQueue.Enqueue((false, key));
                    }
                });
            await Task.WhenAll(tasks.AsParallel());

            bool valid = concurrentQueue.Count == locks * concurrency * 2;

            var entered = new HashSet<string>();

            while (valid && !concurrentQueue.IsEmpty)
            {
                concurrentQueue.TryDequeue(out var result);
                if (result.entered)
                {
                    if (entered.Contains(result.key))
                    {
                        valid = false;
                        break;
                    }
                    entered.Add(result.key);
                }
                else
                {
                    if (!entered.Contains(result.key))
                    {
                        valid = false;
                        break;
                    }
                    entered.Remove(result.key);
                }
            }

            Assert.True(valid);
        }

        [Fact]
        public async Task Test1AtATime()
        {
            var range = 25000;
            var asyncKeyedLocker = new AsyncKeyedLocker<object>(o => { o.PoolSize = 0; });
            var concurrentQueue = new ConcurrentQueue<int>();

            int threadNum = 0;

            var tasks = Enumerable.Range(1, range * 2)
                .Select(async i =>
                {
                    var key = Convert.ToInt32(Math.Ceiling((double)Interlocked.Increment(ref threadNum) / 2));
                    using (await asyncKeyedLocker.LockAsync(key))
                    {
                        concurrentQueue.Enqueue(key);
                    }
                });
            await Task.WhenAll(tasks.AsParallel());

            bool valid = true;
            var list = concurrentQueue.ToList();

            for (int i = 0; i < range; i++)
            {
                if (list[i] == list[i + range])
                {
                    valid = false;
                    break;
                }
            }

            Assert.True(valid);
        }

        [Fact]
        public async Task Test2AtATime()
        {
            var range = 4;
            var asyncKeyedLocker = new AsyncKeyedLocker<object>(o => { o.MaxCount = 2; o.PoolSize = 0; });
            var concurrentQueue = new ConcurrentQueue<int>();

            var tasks = Enumerable.Range(1, range * 4)
                .Select(async i =>
                {
                    var key = Convert.ToInt32(Math.Ceiling((double)i / 4));
                    using (await asyncKeyedLocker.LockAsync(key))
                    {
                        concurrentQueue.Enqueue(key);
                        await Task.Delay((100 * key) + 1000);
                    }
                }).ToList();
            await Task.WhenAll(tasks);

            bool valid = true;
            var list = concurrentQueue.ToList();

            for (int i = 0; i < range * 2; i++)
            {
                if (list[i] != list[i + (range * 2)])
                {
                    valid = false;
                    break;
                }
            }

            Assert.True(valid);
        }

        [Fact]
        public async Task Test1AtATimeGenerics()
        {
            var range = 25000;
            var asyncKeyedLocker = new AsyncKeyedLocker<int>(o => { o.PoolSize = 0; });
            var concurrentQueue = new ConcurrentQueue<int>();

            int threadNum = 0;

            var tasks = Enumerable.Range(1, range * 2)
                .Select(async i =>
                {
                    var key = Convert.ToInt32(Math.Ceiling((double)Interlocked.Increment(ref threadNum) / 2));
                    using (await asyncKeyedLocker.LockAsync(key))
                    {
                        concurrentQueue.Enqueue(key);
                    }
                });
            await Task.WhenAll(tasks.AsParallel());

            bool valid = true;
            var list = concurrentQueue.ToList();

            for (int i = 0; i < range; i++)
            {
                if (list[i] == list[i + range])
                {
                    valid = false;
                    break;
                }
            }

            Assert.True(valid);
        }

        [Fact]
        public async Task Test2AtATimeGenerics()
        {
            var range = 4;
            var asyncKeyedLocker = new AsyncKeyedLocker<int>(o => { o.MaxCount = 2; o.PoolSize = 0; });
            var concurrentQueue = new ConcurrentQueue<int>();

            var tasks = Enumerable.Range(1, range * 4)
                .Select(async i =>
                {
                    var key = Convert.ToInt32(Math.Ceiling((double)i / 4));
                    using (await asyncKeyedLocker.LockAsync(key))
                    {
                        concurrentQueue.Enqueue(key);
                        await Task.Delay((100 * key) + 1000);
                    }
                }).ToList();
            await Task.WhenAll(tasks);

            bool valid = true;
            var list = concurrentQueue.ToList();

            for (int i = 0; i < range * 2; i++)
            {
                if (list[i] != list[i + (range * 2)])
                {
                    valid = false;
                    break;
                }
            }

            Assert.True(valid);
        }

        [Fact]
        public Task TestContinueOnCapturedContextTrue()
            => TestContinueOnCapturedContext(true);

        [Fact]
        public Task TestContinueOnCapturedContextFalse()
            => TestContinueOnCapturedContext(false);

        private async Task TestContinueOnCapturedContext(bool continueOnCapturedContext)
        {
            const string Key = "test";

            var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => { o.PoolSize = 0; });
            var testContext = new TestSynchronizationContext();

            void Callback()
            {
                if (continueOnCapturedContext)
                {
                    Environment.CurrentManagedThreadId.Should().Be(testContext.LastPostThreadId);
                }
                else
                {
                    testContext.LastPostThreadId.Should().Be(default);
                }
            }

            var previousContext = SynchronizationContext.Current;
            SynchronizationContext.SetSynchronizationContext(testContext);

            try
            {
                // This is just to make WaitAsync in TryLockAsync not finish synchronously
                var obj = asyncKeyedLocker.Lock(Key);

                _ = Task.Run(async () =>
                {
                    await Task.Delay(1000);
                    obj.Dispose();
                });

                await asyncKeyedLocker.TryLockAsync(Key, Callback, 5000, continueOnCapturedContext);
            }
            finally
            {
                SynchronizationContext.SetSynchronizationContext(previousContext);
            }
        }

        [Fact]
        public Task TestOptionContinueOnCapturedContext()
                    => TestConfigureAwaitOptions(ConfigureAwaitOptions.ContinueOnCapturedContext);

        [Fact]
        public Task TestOptionForceYielding()
            => TestConfigureAwaitOptions(ConfigureAwaitOptions.ForceYielding);

        private async Task TestConfigureAwaitOptions(ConfigureAwaitOptions configureAwaitOptions)
        {
            const string Key = "test";

            var asyncKeyedLocker = new AsyncKeyedLocker<string>(o => { o.PoolSize = 0; });
            var testContext = new TestSynchronizationContext();

            void Callback()
            {
                if (configureAwaitOptions == ConfigureAwaitOptions.ContinueOnCapturedContext)
                {
                    Environment.CurrentManagedThreadId.Should().Be(testContext.LastPostThreadId);
                }
                else
                {
                    testContext.LastPostThreadId.Should().Be(default);
                }
            }

            var previousContext = SynchronizationContext.Current;
            SynchronizationContext.SetSynchronizationContext(testContext);

            try
            {
                // This is just to make WaitAsync in TryLockAsync not finish synchronously
                var obj = asyncKeyedLocker.Lock(Key);

                _ = Task.Run(async () =>
                {
                    await Task.Delay(1000);
                    obj.Dispose();
                });

                await asyncKeyedLocker.TryLockAsync(Key, Callback, 5000, configureAwaitOptions);
            }
            finally
            {
                SynchronizationContext.SetSynchronizationContext(previousContext);
            }
        }
    }
}