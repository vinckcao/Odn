# Odn

# Bootstrapper 启动器

# Module 模块化思想
* 每个Project作为一个Module 

# Ioc 容器技术

## 特别点
* 抽象了容器，可以接入不同的容器

架构模式：
NHibernate + FluentNHibernate 对领域对象无入侵性. 默认开启延迟加载

兑现的输出， 通过AutoMapper做转换

复杂的表关联， 通过NHibernate Mapping + 延迟加载 + Redis Cache

获取数据： MulitCritialQuery + Stateless Session

IOC做容器管理, 及各个组件内部的对象关联, 做好接口解析

线程语言， 线程身份信息

异常处理机制(对应应用程序框架的异常处理机制, 及对应的异常处理， 接口方面的异常对接)

各个层级的Interception 拦截(Castle.DynamicProxy)

Dto, ViewModel, Entity的规则验证(FluentValidation)

方法访问的授权(Authorization)

Logging机制

Cache机制: 大对象(分布式效率低下)， 零碎对象(分布式支持), 获取对象的重试机制， Connection重试机制

Pub/Sub: 
	AppDomain内部的Pub/Sub(Ioc级别的消息触发, 
	消息执行上下文的线程同步/异步环境, 事务跟主业务线程是否同步还是异步, 异步了之后的事务机制), 
	
	外部的Pub/Sub(外部的消息队列)， RabbitMQ, 通知的类型， 接收的类型

	BusinessConsumer
	ScheduleService(Layer)

	多服务器， 应用程序识别
	配置同步
	缓存清理
