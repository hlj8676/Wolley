local AnimateHelp = { }

AnimateHelp.Ease = CS.DG.Tweening.Ease;
AnimateHelp.DOTween = CS.DG.Tweening.DOTween;

function AnimateHelp.ColorTo(img, delay, dur, var, ease)
	if ease == nil then
		ease = AnimateHelp.Ease.Unset;
	end
	return img:DOColor(var, dur):SetDelay(delay):SetEase(ease);
end

function AnimateHelp.FadeTo(img, delay, dur, var, ease)
	if ease == nil then
		ease = AnimateHelp.Ease.Unset;
	end
	return img:DOFade(var, dur):SetDelay(delay):SetEase(ease);
end

-- ����
function AnimateHelp.FadeIn(img, delay, dur, ease)
	if ease == nil then
		ease = AnimateHelp.Ease.Unset;
	end

	local color = img.color;
	color.a = 0;
	img.color = color;
	return img:DOFade(1, dur):SetDelay(delay):SetEase(ease);
end

-- ����
function AnimateHelp.FadeOut(img, delay, dur, ease)
	if ease == nil then
		ease = AnimateHelp.Ease.Unset;
	end

	local color = img.color;
	color.a = 1;
	img.color = color;
	return img:DOFade(0, dur):SetDelay(delay):SetEase(ease);
end

-- ���ŵ�
function AnimateHelp.ScaleTo(trans, delay, dur, var, ease)
	if ease == nil then
		ease = AnimateHelp.Ease.Unset;
	end
	return trans:DOScale(var, dur):SetDelay(delay):SetEase(ease);
end


-- ���D��
function AnimateHelp.LocalRotateTo(trans, delay, dur, var, ease)
	if ease == nil then
		ease = AnimateHelp.Ease.Unset;
	end
	return trans:DOLocalRotate(var, dur):SetDelay(delay):SetEase(ease);

end

-- �Ƅӵ�
function AnimateHelp.LocalMoveTo(trans, delay, dur, var, ease)
	if ease == nil then
		ease = AnimateHelp.Ease.Unset;
	end
	return trans:DOLocalMove(var, dur):SetDelay(delay):SetEase(ease);

end

-- �Ƅӵ�
function AnimateHelp.MoveTo(trans, delay, dur, var, ease)
	if ease == nil then
		ease = AnimateHelp.Ease.Unset;
	end
	return trans:DOMove(var, dur):SetDelay(delay):SetEase(ease);
end


-- ���S��
function AnimateHelp.LocalJumpTo(trans, delay, dur, var, jumpPower, numJumps, ease)
	if ease == nil then
		ease = AnimateHelp.Ease.Unset;
	end
	return trans:DOLocalJump(var, jumpPower, numJumps, dur):SetDelay(delay):SetEase(ease);

end

-- ���S��
function AnimateHelp.JumpTo(trans, delay, dur, var, jumpPower, numJumps, ease)
	if ease == nil then
		ease = AnimateHelp.Ease.Unset;
	end
	return trans:DOJump(var, jumpPower, numJumps, dur):SetDelay(delay):SetEase(ease);

end

function AnimateHelp.DelayCallBack(delay, func)
	local callback = function()
		if func then
			func();
		end
	end
	AnimateHelp.DOTween:Sequence():OnComplete(callback):SetDelay(delay);
end


function AnimateHelp.Complate(target)
	CS.DG.Tweening.DOTween.Kill(target, true);
end



function AnimateHelp.Sequence()
	return CS.DG.Tweening.DOTween.Sequence();
end



function AnimateHelp.ToValue(func, startValue, endValue, duration)
	return CS.DG.Tweening.DOTween.To(func, startValue, endValue, duration);
end



function AnimateHelp.MaterialFloatTo(material, endValue, property, duration)
	return material:DOFloat(endValue, property, duration);
end



function AnimateHelp.DOLocalPath(trans, path,lookAhead , duration)
	return trans:DOLocalPath(path, duration):SetLookAt(lookAhead);
end

function AnimateHelp.DOLoopType(img,Value)
	return img:DOFade(0, 1):SetLoops(Value,CS.DG.Tweening.LoopType.Yoyo);

end





return AnimateHelp;
